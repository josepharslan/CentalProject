using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminBrandController(IBrandService _brandService) : Controller
    {
        public IActionResult Index(int page = 1, int pageSize = 3)
        {
            var brand = _brandService.TGetAll().AsQueryable();
            var value = new PagedList<Brand>(brand, page, pageSize);
            return View(value);
        }
        public IActionResult DeleteBrand(int id)
        {
            _brandService.TDelete(id);
            return RedirectToAction("Index");
        }
        public IActionResult CreateBrand()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBrand(Brand model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _brandService.TCreate(model);
            return RedirectToAction("Index");
        }

        //To Do UpdateBrand
    }
}
