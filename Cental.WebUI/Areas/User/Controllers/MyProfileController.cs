using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cental.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class MyProfileController(UserManager<AppUser> _userManager, IImageService _imageService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = user.Adapt<ProfileEditDto>();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> Index(ProfileEditDto model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var succeed = await _userManager.CheckPasswordAsync(values, model.CurrentPassword);

            if (succeed)
            {
                if (model.ImageFile != null)
                {
                    try
                    {
                        model.ImageUrl = await _imageService.SaveImageAsync(model.ImageFile);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                        return View(model);
                    }
                }

                values.FirstName = model.FirstName;
                values.LastName = model.LastName;
                values.Email = model.Email;
                values.PhoneNumber = model.PhoneNumber;
                values.ImageUrl = model.ImageUrl;

                var updateUser = model.Adapt<AppUser>();

                var result = await _userManager.UpdateAsync(values);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "MyProfile");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
            ModelState.AddModelError("", "Girdiğiniz şifre hatalı.");
            return View(model);
        }
    }
}
