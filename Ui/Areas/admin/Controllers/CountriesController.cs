using BL.Contract;
using BL.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ui.Helpers;

namespace Ui.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class CountriesController : Controller
    {
        private readonly ICountry _country;
        private readonly ILogger<CountriesController> _logger;
        public CountriesController(ICountry shippingType, ILogger<CountriesController> logger)
        {
            _country = shippingType;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var data = _country.GetAll();
            return View(data);
        }

        public IActionResult Edit(Guid? Id)
        {
            TempData["MessageType"] = null;
            var data = new CountryDto();
            if(Id != null) 
            {
                data = _country.GetById((Guid)Id);
            }
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(CountryDto data) 
        {
            TempData["MessageType"] = null;
            if(!ModelState.IsValid)
                return View("Edit",data);
            try
            {
                if (data.Id == Guid.Empty)
                    _country.Add(data);
                else
                    _country.Update(data);

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
                _country.ChangeStatus(Id,0);
                TempData["MessageType"] = MessageTypes.DeleteSucess;
            }
            catch (Exception ex)
            {
                TempData["MessageType"] = MessageTypes.DeleteFailed;
                _logger.LogError(ex, "Failed to change status for Countries ID: {Id}", Id);
                throw new Exception("save failed error", ex);
            }
            return RedirectToAction("Index");
        }
    }
}
