using BL.Contract;
using BL.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ui.Helpers;

namespace Ui.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class ShippingTypesController : Controller
    {
        private readonly IShippingType _shippingType;
        private readonly ILogger<ShippingTypesController> _logger;
        public ShippingTypesController(IShippingType shippingType, ILogger<ShippingTypesController> logger)
        {
            _shippingType = shippingType;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var data = _shippingType.GetAll();
            return View(data);
        }

        public IActionResult Edit(Guid? Id)
        {
            TempData["MessageType"] = null;
            var data = new ShippingTypeDto();
            if(Id != null) 
            {
                data = _shippingType.GetById((Guid)Id);
            }
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(ShippingTypeDto data) 
        {
            TempData["MessageType"] = null;
            if(!ModelState.IsValid)
                return View("Edit",data);
            try
            {
                if (data.Id == Guid.Empty)
                    _shippingType.Add(data);
                else
                    _shippingType.Update(data);

                TempData["MessageType"] = MessageTypes.SaveSucess;
            }
            catch (Exception ex)
            {
                TempData["MessageType"] = MessageTypes.SaveFailed;
                throw new Exception("save failed error", ex);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid Id) 
        {
            TempData["MessageType"] = null;
            try
            {
                _shippingType.ChangeStatus(Id,0);
                TempData["MessageType"] = MessageTypes.DeleteSucess;
            }
            catch (Exception ex)
            {
                TempData["MessageType"] = MessageTypes.DeleteFailed;
                _logger.LogError(ex, "Failed to change status for shipping type ID: {Id}", Id);
                throw new Exception("save failed error", ex);
            }
            return RedirectToAction("Index");
        }
    }
}
