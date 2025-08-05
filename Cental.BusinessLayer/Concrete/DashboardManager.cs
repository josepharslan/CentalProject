using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Repositories;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class DashboardManager : IDashboardService
    {
        private readonly IDashboardDal _dashboardDal;

        public DashboardManager(IDashboardDal dashboardDal)
        {
            _dashboardDal = dashboardDal;
        }

        public async Task<DashboardStatistics> GetDashboardDataAsync()
        {
            var statistics = await _dashboardDal.GetDashboardStatisticsAsync();
            return statistics;
        }
    }
}

