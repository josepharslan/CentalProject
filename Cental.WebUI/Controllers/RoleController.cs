using Cental.DtoLayer.RoleDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController(RoleManager<AppRole> _roleManager) : Controller
    {
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();

            var dto = roles.Adapt<List<ResultRoleDto>>();
            return View(dto);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleDto createRoleDto)
        {
            var role = createRoleDto.Adapt<AppRole>();

            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            await _roleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            var updateDto = role.Adapt<UpdateRoleDto>();
            return View(updateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateRoleDto updateRoleDto)
        {
            var role = updateRoleDto.Adapt<AppRole>();
            var result = await _roleManager.UpdateAsync(role);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(updateRoleDto);
            }
            return RedirectToAction("Index");
        }
    }
}
