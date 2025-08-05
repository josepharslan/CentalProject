using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminProcessController(IProcessService _processService) : Controller
    {
        public IActionResult Index()
        {
            var value = _processService.TGetAll();
            return View(value);
        }
        public IActionResult CreateProcess()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProcess(Process process)
        {
            _processService.TCreate(process);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProcess(int id)
        {
            _processService.TDelete(id);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateProcess(int id)
        {
            var value = _processService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateProcess(Process model)
        {
            var value = _processService.TGetById(model.ProcessId);
            value.Title = model.Title;
            value.Description = model.Description;
            _processService.TUpdate(value);
            return RedirectToAction("Index");

        }
    }
}
