using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController(SignInManager<AppUser> _signInManager) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(string? returnUrl)
        {
            await _signInManager.SignOutAsync();
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginDto model, string? returnUrl)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı");
                return View(model);
            }
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "AdminAbout");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Default");
        }
    }
}
