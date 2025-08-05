using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.TestimonialDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminTestimonialController(ITestimonialService _testimonialService, IImageService _imageService) : Controller
    {
        public IActionResult Index()
        {
            var values = _testimonialService.TGetAll();
            var dto = values.Adapt<List<ResultTestimonialDto>>();
            return View(dto);
        }
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.ImageFile != null)
            {
                model.ImageUrl = await _imageService.SaveImageAsync(model.ImageFile);
            }

            var dto = model.Adapt<Testimonial>();
            _testimonialService.TCreate(dto);

            return RedirectToAction("Index");
        }

        public IActionResult UpdateTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            var dto = value.Adapt<UpdateTestimonialDto>();
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var testimonial = _testimonialService.TGetById(model.TestimonialId);

            if (model.ImageFile != null)
            {
                model.ImageUrl = await _imageService.SaveImageAsync(model.ImageFile);

            }

            testimonial.Title = model.Title;
            testimonial.ReviewStar = model.ReviewStar;
            testimonial.ImageUrl = model.ImageUrl;
            testimonial.Name = model.Name;
            testimonial.Comment = model.Comment;

            _testimonialService.TUpdate(testimonial);

            return RedirectToAction("Index");
        }
        public IActionResult DeleteTestimonial(int id)
        {
            _testimonialService.TDelete(id);
            return RedirectToAction("Index");
        }
    }
}