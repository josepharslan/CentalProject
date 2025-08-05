using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.FeatureDtos;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultFeatureComponent(IFeatureService _featureService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var value = _featureService.TGetAll();
            var dto = value.Adapt<List<ResultFeatureDto>>();
            return View(dto);
        }
    }
}
