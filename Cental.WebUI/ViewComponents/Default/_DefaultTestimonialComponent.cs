using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.TestimonialDtos;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultTestimonialComponent(ITestimonialService _testimonialService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var value = _testimonialService.TGetAll();
            var dto = value.Adapt<List<ResultTestimonialDto>>();
            return View(dto);
        }
    }
}
