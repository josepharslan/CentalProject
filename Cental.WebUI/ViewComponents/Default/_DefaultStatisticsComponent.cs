using Cental.BusinessLayer.Abstract;
using Cental.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultStatisticsComponent(IDashboardService _dashboardService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
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
