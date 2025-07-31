using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController(SignInManager<AppUser> _signInManager, UserManager<AppUser> _userManager) : Controller
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

            var user = await _userManager.FindByNameAsync(model.UserName);

            var userRole = await _userManager.GetRolesAsync(user);
            if (userRole != null)
            {
                if (userRole.Contains("Admin"))
                {
                    return RedirectToAction("Index", "AdminAbout");
                }
                else if (userRole.Contains("Manager"))
                {
                    return RedirectToAction("Index", "MySocial", new { area = "Manager" });
                }
                else if (userRole.Contains("User"))
                {
                    return RedirectToAction("Index", "MyProfile", new { area = "User" });
                }
            }
            return RedirectToAction("Index", "Default");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Default");
        }
    }
}
