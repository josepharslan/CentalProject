using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BannerDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminBannerController(IBannerService _bannerService, IMapper _mapper) : Controller
    {

        public IActionResult Index()
        {
            var value = _bannerService.TGetAll();
            var banners = _mapper.Map<List<ResultBannerDto>>(value);
            return View(banners);
        }
        public IActionResult CreateBanner()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBanner(CreateBannerDto model)
        {
            var banner = _mapper.Map<Banner>(model);
            _bannerService.TCreate(banner);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateBanner(int id)
        {
            var value = _bannerService.TGetById(id);
            return View(id);
        }
    }
}
