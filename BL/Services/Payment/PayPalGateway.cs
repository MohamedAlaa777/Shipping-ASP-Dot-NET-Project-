using BL.Contract;
using BL.Dtos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BL.Services.Payment
{
    public class PayPalGateway : IPaymentGateway
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;

        public PayPalGateway(HttpClient client, IConfiguration config)
        {
            _client = client;
            _config = config;
        }

        private async Task<string> GetAccessTokenAsync()
        {
            var clientId = _config["PayPal:ClientId"];
            var secret = _config["PayPal:Secret"];
            var env = _config["PayPal:Environment"];
            var url = env == "live"
                ? "https://api.paypal.com/v1/oauth2/token"
                : "https://api-m.sandbox.paypal.com/v1/oauth2/token";

            var authHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{secret}"));
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", authHeader);
            request.Content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var token = JsonSerializer.Deserialize<JsonElement>(content).GetProperty("access_token").GetString();
            return token;
        }

        public async Task<(string, bool)> CreateOrder(CreatePaymentRequest requestData)
        {
            try
            {
                var env = _config["PayPal:Environment"];
                var url = env == "live"
                    ? "https://api.paypal.com/v2/checkout/orders"
                    : "https://api-m.sandbox.paypal.com/v2/checkout/orders";

                var accessToken = await GetAccessTokenAsync();
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                // 🧮 Calculate total amount
                var total = requestData.Items.Sum(item => item.Price * item.Quantity);

                // 🧾 Convert to PayPal items
                var items = requestData.Items.Select(item => new
                {
                    name = item.Name,
                    description = item.Description,
                    unit_amount = new
                    {
                        currency_code = "USD",
                        value = item.Price.ToString("F2")
                    },
                    quantity = item.Quantity.ToString(),
                    category = "PHYSICAL_GOODS"
                });

                var body = new
                {
                    intent = "CAPTURE",
                    purchase_units = new[]
                    {
                    new
                    {
                        amount = new
                        {
                            currency_code = "USD",
                            value = total.ToString("F2"),
                            breakdown = new
                            {
                                item_total = new
                                {
                                    currency_code = "USD",
                                    value = total.ToString("F2")
                                }
                            }
                        },
                        items = items,
                    }
                }
                };

                request.Content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

                var response = await _client.SendAsync(request);
                var result = await response.Content.ReadAsStringAsync();
                var json = JsonSerializer.Deserialize<JsonElement>(result);

                string orderId = json.GetProperty("id").GetString();
                return (orderId, response.IsSuccessStatusCode);
            }
            catch (Exception ex)
            {
                return (ex.Message, false);
            }
        }

        public async Task<(string, bool)> CaptureOrder(string orderId)
        {
            try
            {
                var env = _config["PayPal:Environment"];
                var baseUrl = env == "live"
                    ? "https://api.paypal.com"
                    : "https://api-m.sandbox.paypal.com";

                var url = $"{baseUrl}/v2/checkout/orders/{orderId}/capture";

                var accessToken = await GetAccessTokenAsync();

                using var req = new HttpRequestMessage(HttpMethod.Post, url);
                req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                req.Headers.Accept.Clear();
                req.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // اختياري: رجّع التمثيل الكامل للطلب في الرد
                req.Headers.TryAddWithoutValidation("Prefer", "return=representation");
                // مهم: جسم JSON فاضي + Content-Type: application/json
                req.Content = new StringContent("{}", Encoding.UTF8, "application/json");
                // اختياري: لضمان idempotency لو حصل retry
                req.Headers.TryAddWithoutValidation("PayPal-Request-Id", Guid.NewGuid().ToString("N"));

                var resp = await _client.SendAsync(req);
                var body = await resp.Content.ReadAsStringAsync();

                // PayPal غالبًا بيرجع 201 Created عند الـ capture الناجح
                var ok = resp.IsSuccessStatusCode;

                // لو فشل، حاول طباعة الـ debug_id للمساعدة في التتبع
                if (!ok && !string.IsNullOrWhiteSpace(body) && body.Contains("debug_id"))
                {
                    // سجّله في اللوج عندك

                }

                return (body, ok);
            }
            catch (Exception ex)
            {
                return ($"EX: {ex.Message}", false);
            }
        }

    }
}
