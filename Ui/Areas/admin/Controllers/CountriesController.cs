using BL.Contract;
using BL.Dtos;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ui.Helpers;

namespace Ui.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class CountriesController : Controller
    {
        private readonly ICountry _ICountry;
        private readonly ILogger<CountriesController> _logger;
        public CountriesController(ICountry shippingType, ILogger<CountriesController> logger)
        {
            _ICountry = shippingType;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _ICountry.GetAll();
            return View(data);
        }

        public async Task<IActionResult> Edit(Guid? Id)
        {
            TempData["MessageType"] = null;
            var data = new BL.Dtos.CountryDto();
            if (Id != null)
            {
                data = await _ICountry.GetById((Guid)Id);
            }
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(CountryDto data)
        {
            TempData["MessageType"] = null;
            if (!ModelState.IsValid)
                return View("Edit", data);
            try
            {
                if (data.Id == Guid.Empty)
                    await _ICountry.Add(data);
                else
                    await _ICountry.Update(data);
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
                await _ICountry.ChangeStatus(Id, 0);
                TempData["MessageType"] = MessageTypes.DeleteSucess;
            }
            catch (Exception ex)
            {
                TempData["MessageType"] = MessageTypes.DeleteFailed;
            }

            return RedirectToAction("Index");
        }
    }
}
