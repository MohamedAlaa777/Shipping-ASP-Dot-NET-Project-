using BL.Contract;
using BL.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Ui.Helpers;
namespace Ui.Areas.admin.Controllers
{
    [Area("admin")]
    public class CitiesController : Controller
    {
        private readonly ICity _ICity;
        private readonly ICountry _ICountry;
        private readonly ILogger<CitiesController> _logger;
        public CitiesController(ICity ICity, ICountry iCountry, ILogger<CitiesController> logger)
        {
            _ICity = ICity;
            _ICountry = iCountry;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var data = _ICity.GetAllCitites();
            return View(data);
        }

        public IActionResult Edit(Guid? Id)
        {
            TempData["MessageType"] = null;
            var data = new CityDto();
            LoadCountries();
            if (Id != null)
            {
                data = _ICity.GetById((Guid)Id);
            }
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(CityDto data)
        {
            TempData["MessageType"] = null;
            if (!ModelState.IsValid)
            {
                LoadCountries();
                return View("Edit", data);
            }

            try
            {
                if (data.Id == Guid.Empty)
                    _ICity.Add(data);
                else
                    _ICity.Update(data);
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
                _ICity.ChangeStatus(Id, 0);
                TempData["MessageType"] = MessageTypes.DeleteSucess;
            }
            catch (Exception ex)
            {
                TempData["MessageType"] = MessageTypes.DeleteFailed;
                _logger.LogError(ex, "Failed to change status for Cities ID: {Id}", Id);
                throw new Exception("save failed error", ex);
            }

            return RedirectToAction("Index");
        }

        void LoadCountries()
        {
            var countries = _ICountry.GetAll() ?? new List<CountryDto>(); // adjust to match your actual model
            ViewBag.Countries = countries;
        }

    }
}
