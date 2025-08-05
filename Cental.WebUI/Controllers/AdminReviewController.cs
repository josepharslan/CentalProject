using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ReviewDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminReviewController(IReviewService _reviewService, IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {
            var value = _reviewService.TGetAll();
            var dto = _mapper.Map<List<ResultReviewDto>>(value);
            return View(dto);
        }
    }
}
