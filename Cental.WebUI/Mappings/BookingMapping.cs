using AutoMapper;
using Cental.DtoLayer.BookingDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class BookingMapping : Profile
    {
        public BookingMapping()
        {
            CreateMap<Booking, ResultBookingDto>()
                .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Car.ModelName))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Car.Brand.BrandName));
        }
    }
}
