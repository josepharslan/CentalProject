using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminCarController(ICarService _carService) : Controller
    {
        public IActionResult Index()
        {
            var value = _carService.TGetCarsWithBrands();
            return View(value);
        }
    }
}
