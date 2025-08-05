using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultProcessComponent(IProcessService _processService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var value = _processService.TGetAll();
            return View(value);
        }
    }
}
