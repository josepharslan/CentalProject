using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BookingDtos;
using Cental.EntityLayer.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController(IBookingService _bookingService, IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BookCar(CreateBookingDto model)
        {
            //var dto = _mapper.Map<Booking>(model);
            //_bookingService.TCreate(dto);
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
