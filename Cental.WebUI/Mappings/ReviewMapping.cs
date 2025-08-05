using AutoMapper;
using Cental.DtoLayer.BookingDtos;
using Cental.DtoLayer.ReviewDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class ReviewMapping : Profile
    {
        public ReviewMapping()
        {
            CreateMap<Review, ResultReviewDto>()
                .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Car.ModelName))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Car.Brand.BrandName));
        }
    }
}
