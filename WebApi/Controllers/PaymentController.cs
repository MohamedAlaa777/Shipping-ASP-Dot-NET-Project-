using BL.Contract;
using BL.Dtos;
using BL.Services.Payment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        IPaymentGateway _paymentGateway;
        public PaymentController(PaymentFactory gateway) 
        {
            _paymentGateway=gateway.GetPaymentGateway("US");
        }

        [HttpPost("create-order")]
        public async Task<IActionResult> CreateOrder([FromBody] CreatePaymentRequest data)
        {
            var result = await _paymentGateway.CreateOrder(data);
            return Ok(new { id = result.Item1 });
        }

        [HttpPost("capture-order")]
        public async Task<IActionResult> CaptureOrder([FromBody] PaymentDto data)
        {
            var result = await _paymentGateway.CaptureOrder(data.OrderId);
            return Ok(JsonDocument.Parse(result.Item1));
        }
    }
}
