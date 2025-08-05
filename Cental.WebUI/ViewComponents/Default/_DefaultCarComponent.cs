using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultCarComponent(ICarService _carService, IMapper _mapper) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var value = _carService.TGetAll().TakeLast(6);
            return View(value.ToList());
        }
    }
}
