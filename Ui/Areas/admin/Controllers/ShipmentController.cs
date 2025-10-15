using BL.Contract;
using BL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ui.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class ShipmentController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IShipmentQuery _IShipment;
        public ShipmentController(ILogger<HomeController> logger, IShipmentQuery iGenericRepository)
        {
            _logger = logger;
            _IShipment = iGenericRepository;
        }

        public async Task<IActionResult> IndexAsync(int page = 1)
        {
            ShipmentStatusEnum? status = ShipmentStatusEnum.Created;
            if (User.IsInRole("Admin"))
                status = null;
            else if (User.IsInRole("Reviewer"))
                status = ShipmentStatusEnum.Created;
            else if (User.IsInRole("Operation"))
                status = ShipmentStatusEnum.Approved;
            else if (User.IsInRole("Operation Manager"))
                status = ShipmentStatusEnum.ReadyForShip;

            var shipments = await _IShipment.GetShipments(page, 10, false, status);
            return View(shipments);
        }

        public IActionResult Edit(Guid? id)
        {
            return View();
        }
    }
}
