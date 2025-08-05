using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ContactDtos;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UILayout
{
    public class UITopbarComponent(IContactService _contactService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var value = _contactService.TGetById(1);
            var dto = value.Adapt<ResultContactDto>();
            return View(dto);
        }
    }
}
