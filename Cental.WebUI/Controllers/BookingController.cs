using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BookingDtos;
using Cental.EntityLayer.Entities;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BookingController(IBookingService _bookingService, IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {
            var value = _bookingService.TGetAll()
                .OrderBy(x => x.Status == "Onay Bekliyor" ? 0 : 1)
                .ThenBy(x => x.Status).ToList();
            var dto = _mapper.Map<List<ResultBookingDto>>(value);
            return View(dto);
        }
        public IActionResult ConfirmBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            value.Status = "Onaylandı";
            _bookingService.TUpdate(value);
            return RedirectToAction("Index");
        }
        public IActionResult CancelBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            value.Status = "İptal Edildi";
            _bookingService.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}
