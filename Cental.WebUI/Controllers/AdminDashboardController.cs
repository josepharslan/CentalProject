using Cental.BusinessLayer.Abstract;
using Cental.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminDashboardController(IDashboardService _dashboardService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var value = await _dashboardService.GetDashboardDataAsync();

            var viewModel = new DashboardViewModel()
            {
                Statistics = value
            };
            return View(viewModel);
        }
    }
}
