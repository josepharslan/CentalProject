using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleAssignController(UserManager<AppUser> _userManager, RoleManager<AppRole> _roleManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();

            var userdto = new List<ResultUserDto>();
            foreach (var user in users)
            {
                var dto = new ResultUserDto();
                dto.Roles = await _userManager.GetRolesAsync(user);

                dto.Id = user.Id;
                dto.FirstName = user.FirstName;
                dto.LastName = user.LastName;
                dto.UserName = user.UserName;
                dto.Email = user.Email;

                userdto.Add(dto);
            }
            return View(userdto);
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            ViewBag.fullName = string.Join(" ", user.FirstName, user.LastName);
            var roles = await _roleManager.Roles.ToListAsync();
            var userRoles = await _userManager.GetRolesAsync(user);

            var assignRoleDtoList = new List<AssignRoleDto>();
            foreach (var item in roles)
            {
                var model = new AssignRoleDto();
                model.UserId = user.Id;
                model.RoleName = item.Name;
                model.RoleId = item.Id;
                model.RoleExist = userRoles.Contains(item.Name);

                assignRoleDtoList.Add(model);
            }

            return View(assignRoleDtoList);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDto> model)
        {
            if (model == null || !model.Any())
                return BadRequest();

            var userId = model.First().UserId;
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return NotFound();

            foreach (var item in model)
            {
                bool isInRole = await _userManager.IsInRoleAsync(user, item.RoleName);

                if (item.RoleExist && !isInRole)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else if (!item.RoleExist && isInRole)
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }

            return RedirectToAction("Index");
        }


    }
}
