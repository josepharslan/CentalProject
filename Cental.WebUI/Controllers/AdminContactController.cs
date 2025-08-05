using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ContactDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminContactController(IContactService _contactService) : Controller
    {
        public IActionResult Index()
        {
            var values = _contactService.TGetAll();
            var dto = values.Adapt<List<ResultContactDto>>();
            return View(dto);
        }
        public IActionResult UpdateContact(int id)
        {
            var value = _contactService.TGetById(id);
            var dto = value.Adapt<ResultContactDto>();
            return View(dto);
        }
        [HttpPost]
        public IActionResult UpdateContact(ResultContactDto contact)
        {
            var value = _contactService.TGetById(contact.Id);
            contact.Adapt(value);
            _contactService.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}
