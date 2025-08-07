using BL.Contract;
using BL.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Ui.Models;

namespace Ui.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IShipment _IGenericRepository;
        public HomeController(ILogger<HomeController> logger, IShipment iGenericRepository)
        {
            _logger = logger;
            _IGenericRepository = iGenericRepository;
        }

        void TestShipment()
        {
            var testShipment = new ShippmentDto
            {
                Id = Guid.NewGuid(),
                ShipingDate = DateTime.UtcNow,
                DelivryDate = DateTime.UtcNow.AddDays(3),

                SenderId = Guid.Empty,
                UserSender = new UserSenderDto
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    SenderName = "Ali Sender",
                    Email = "sender@example.com",
                    Phone = "01012345678",
                    PostalCode = "12345",
                    Contact = "Ali Sender Contact",
                    OtherAddress = "Apartment 5B, Sender Tower",
                    IsDefault = true,
                    CityId = Guid.Parse("5c201805-5e68-45f9-b601-3b0144a0c9b8"),
                    Address = "123 Sender Street"
                },

                ReceiverId = Guid.Empty,
                UserReceiver = new UserReceiverDto
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    ReceiverName = "Omar Receiver",
                    Email = "receiver@example.com",
                    Phone = "01087654321",
                    PostalCode = "54321",
                    Contact = "Omar Receiver Contact",
                    OtherAddress = "Floor 2, Receiver Building",
                    CityId = Guid.Parse("5c201805-5e68-45f9-b601-3b0144a0c9b8"),
                    Address = "456 Receiver Road"
                },

                ShippingTypeId = Guid.Parse("459afb92-3374-4b02-ac67-086590009462"),
                ShipingPackgingId = null, // optional
                Width = 25.0,
                Height = 15.0,
                Weight = 5.5,
                Length = 30.0,
                PackageValue = 1000m,
                ShippingRate = 75.0m,
                PaymentMethodId = null,
                UserSubscriptionId = null,
                TrackingNumber = 10000001,
                ReferenceId = Guid.NewGuid()
            };
            _IGenericRepository.Create(testShipment);
        }

        public IActionResult Index()
        {
            //TestShipment();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
