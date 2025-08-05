using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.FeatureDtos;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminFeatureController(IFeatureService _featureService) : Controller
    {
        public IActionResult Index()
        {
            var values = _featureService.TGetAll();
            var dto = values.Adapt<List<ResultFeatureDto>>();
            return View(dto);
        }
        public IActionResult Update(int id)
        {
            var value = _featureService.TGetById(id);
            var dto = value.Adapt<ResultFeatureDto>();
            return View(dto);
        }
        [HttpPost]
        public IActionResult Update(ResultFeatureDto model)
        {
            var entity = _featureService.TGetById(model.FeatureId);
            if (entity == null)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);
 
            model.Adapt(entity);

            _featureService.TUpdate(entity);
            return RedirectToAction("Index");
        }

    }
}
