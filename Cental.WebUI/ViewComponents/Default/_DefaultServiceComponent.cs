using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ServiceDtos;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultServiceComponent(IServiceService _serviceService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var value = _serviceService.TGetAll();
            var dto = value.Adapt<List<ResultServiceDto>>();
            return View(dto);
        }
    }
}
