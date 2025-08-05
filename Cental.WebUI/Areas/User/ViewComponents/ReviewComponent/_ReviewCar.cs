using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ReviewDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.User.ViewComponents.ReviewComponent
{
    public class _ReviewCar(IReviewService _reviewService) : ViewComponent
    {
        public IViewComponentResult Invoke(int carId)
        {
            var model = new CreateReviewDto { CarId = carId };
            return View(model);
        }
    }
}
