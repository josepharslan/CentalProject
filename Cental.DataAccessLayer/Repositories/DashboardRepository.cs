using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Repositories
{
    public class DashboardRepository : IDashboardDal
    {
        private readonly CentalContext _centalContext;

        public DashboardRepository(CentalContext centalContext)
        {
            _centalContext = centalContext;
        }


        public async Task<DashboardStatistics> GetDashboardStatisticsAsync()
        {
            var today = DateTime.Today;
            var firstDayOfMonth = new DateTime(today.Year, today.Month, 1);

            var stats = new DashboardStatistics
            {
                TotalCars = await _centalContext.Cars.CountAsync(),
                AvailableCars = await _centalContext.Bookings.Where(x => x.Status != "İptal Edildi").CountAsync(),
                RentedCars = await _centalContext.Bookings.Where(c => c.Status == "Onaylandı").CountAsync(),
                TotalUsers = await _centalContext.Users.CountAsync()
            };

            return stats;
        }
    }
}
