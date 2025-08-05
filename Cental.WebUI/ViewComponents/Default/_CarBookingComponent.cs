using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _CarBookingComponent(ICarService _carService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.cars = (from x in _carService.TGetAll()
                            select new SelectListItem
                            {
                                Text = x.Brand.BrandName + " " + x.ModelName,
                                Value = x.CarId.ToString()
                            }).ToList();
            return View();
        }
    }
}
