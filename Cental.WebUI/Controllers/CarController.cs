using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.Enums;
using Cental.EntityLayer.Entities;
using Cental.WebUI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class CarController(ICarService _carService, IBrandService _brandService) : Controller
    {
        public IActionResult Index()
        {
            if (TempData["filteredCars"] != null)
            {
                var data = TempData["filteredCars"].ToString();
                if (data != null)
                {
                    var filterCars = JsonSerializer.Deserialize<List<Car>>(data, new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.IgnoreCycles
                    });
                    return View(filterCars);
                }
            }
            var values = _carService.TGetAll();
            return View(values);
        }

        public PartialViewResult Filter()
        {
            var cars = _carService.TGetAll();

            ViewBag.cars = (from x in cars
                            select new SelectListItem
                            {
                                Text = x.Brand.BrandName + " " + x.ModelName,
                                Value = x.Brand.BrandName + " " + x.ModelName,
                            }).ToList();
            ViewBag.gasTypes = GetEnumValues.GetEnums<GasTypes>();
            ViewBag.gearTypes = GetEnumValues.GetEnums<GearTypes>();

            return PartialView();
        }
        [HttpPost]
        public IActionResult Filter(string gear, string car, int year, string gas)
        {
            if (!string.IsNullOrEmpty(car) || !string.IsNullOrEmpty(gear) || !string.IsNullOrEmpty(gas) || year > 0)
            {
                var cars = _carService.TGetAll();
                var filteredCars = cars.Where(x => x.GearType.ToString() == gear && x.Brand.BrandName + " " + x.ModelName == car && x.GasType.ToString() == gas && x.Year >= year).ToList();
                TempData["filteredCars"] = JsonSerializer.Serialize(filteredCars, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles
                });
            }
            return RedirectToAction("Index");

        }
    }
}
