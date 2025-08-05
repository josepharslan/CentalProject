using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Models
{
    public class DashboardViewModel
    {
        public DashboardStatistics Statistics { get; set; }

        public DashboardViewModel()
        {
            Statistics = new DashboardStatistics();

        }
    }
}