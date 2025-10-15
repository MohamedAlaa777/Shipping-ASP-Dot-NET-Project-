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
        public async Task<IActionResult> Index()
        {
            var data = await _ICity.GetAllCitites();
            return View(data);
        }

        public async Task<IActionResult> Edit(Guid? Id)
        {
            TempData["MessageType"] = null;
            var data = new BL.Dtos.CityDto();
            await LoadCountries();
            if (Id != null)
            {
                data = await _ICity.GetById((Guid)Id);
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
                await LoadCountries();
                return View("Edit", data);
            }

            try
            {
                if (data.Id == Guid.Empty)
                    await _ICity.Add(data);
                else
                    await _ICity.Update(data);
                TempData["MessageType"] = MessageTypes.SaveSucess;
            }
            catch (Exception ex)
            {
                TempData["MessageType"] = MessageTypes.SaveFailed;
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid Id)
        {
            TempData["MessageType"] = null;
            try
            {
                await _ICity.ChangeStatus(Id, 0);
                TempData["MessageType"] = MessageTypes.DeleteSucess;
            }
            catch (Exception ex)
            {
                TempData["MessageType"] = MessageTypes.DeleteFailed;
            }

            return RedirectToAction("Index");
        }

        async Task LoadCountries()
        {
            var countries = await _ICountry.GetAll();
            ViewBag.Countries = countries;
        }

    }
}
