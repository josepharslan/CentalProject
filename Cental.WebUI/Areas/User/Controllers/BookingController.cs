using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BookingDtos;
using Cental.DtoLayer.ReviewDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Cental.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class BookingController(IBookingService _bookingService, UserManager<AppUser> _userManager, IMapper _mapper, IReviewService _reviewService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = user.Id;

            var values = _bookingService.TGetBookingsByUserId(userId);

            var dto = _mapper.Map<List<ResultBookingDto>>(values);
            return View(dto);
        }
        [HttpPost]
        public IActionResult ReviewCar(CreateReviewDto model)
        {
            if (ModelState.IsValid)
            {
                var review = model.Adapt<Review>();
                _reviewService.TCreate(review);
            }
            else
            {

            }
            return RedirectToAction("Index");
        }
    }
}
