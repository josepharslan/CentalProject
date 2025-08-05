using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ServiceDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminServiceController(IServiceService _serviceService) : Controller
    {
        public IActionResult Index()
        {
            var value = _serviceService.TGetAll();
            var dto = value.Adapt<List<ResultServiceDto>>();
            return View(dto);
        }
        public IActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateService(CreateServiceDto dto)
        {
            var value = dto.Adapt<Service>();
            _serviceService.TCreate(value);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateService(int id)
        {
            var value = _serviceService.TGetById(id);
            var dto = value.Adapt<UpdateServiceDto>();
            return View(dto);
        }
        [HttpPost]
        public IActionResult UpdateService(UpdateServiceDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var value = _serviceService.TGetById(dto.ServiceId);
            if (value == null)
            {
                return NotFound();
            }

            dto.Adapt(value);
            _serviceService.TUpdate(value);

            return RedirectToAction("Index");
        }
        public IActionResult DeleteService(int id)
        {
            _serviceService.TDelete(id);
            return RedirectToAction("Index");
        }
    }
}

