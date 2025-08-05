using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BannerDtos;
using Cental.DtoLayer.BookingDtos;
using Cental.EntityLayer.Entities;
using Cental.WebUI.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController(IBookingService _bookingService, UserManager<AppUser> _userManager, IBannerService _bannerService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BookCar(CreateBookingDto model)
        {
            var userName = User.Identity?.Name;
            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("Index", "Login");
            }
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            model.Status = "Onay Bekliyor";

            var dto = model.Adapt<Booking>();
            dto.AppUserId = user.Id;
            _bookingService.TCreate(dto);
            if (ModelState.IsValid)
            {
                TempData["BookingResult"] = "success";
            }
            else
            {
                TempData["BookingResult"] = "error";
            }
            return RedirectToAction("Index");
        }
    }
}
