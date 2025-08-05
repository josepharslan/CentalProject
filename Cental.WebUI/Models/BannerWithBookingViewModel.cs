using Cental.DtoLayer.BannerDtos;
using Cental.DtoLayer.BookingDtos;

namespace Cental.WebUI.Models
{
    public class BannerWithBookingViewModel
    {
        public ResultBannerDto Banner { get; set; }
        public CreateBookingDto Booking { get; set; }
    }
}
