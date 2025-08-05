using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ReviewDtos;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cental.WebUI.ViewComponents.AdminDashboard
{
    public class _DashboardReviewsComponent(IReviewService _reviewService, IMapper _mapper) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var value = _reviewService.TGetAll();
            var dto = _mapper.Map<List<ResultReviewDto>>(value);
            return View(dto);
        }
    }
}
