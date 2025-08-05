using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.DataAccessLayer.Repositories;
using Cental.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Concrete
{
    public class EfDashboardDal : IDashboardDal
    {
        private readonly CentalContext _context;

        public EfDashboardDal(CentalContext context)
        {
            _context = context;
        }

        public async Task<DashboardStatistics> GetDashboardStatisticsAsync()
        {
            {
                var today = DateTime.Today;
                var firstDayOfMonth = new DateTime(today.Year, today.Month, 1);

                var statistics = new DashboardStatistics
                {
                    TotalCars = await _context.Cars.CountAsync(),

                    AvailableCars = await _context.Cars.Where(car => !_context.Bookings.Any(b => b.CarId == car.CarId && b.Status == "Onaylandı" && b.StartDate <= today && b.EndDate >= today)).CountAsync(),

                    RentedCars = await _context.Cars.Where(car => _context.Bookings.Any(b => b.CarId == car.CarId && b.Status == "Onaylandı" && b.StartDate <= today && b.EndDate >= today)).CountAsync(),
                    TotalUsers = await _context.Users.CountAsync(),

                    ActiveRentals = await _context.Bookings.Where(b => b.Status == "Onaylandı" && b.StartDate <= today && b.EndDate >= today).CountAsync(),
                };
                return statistics;
            }
        }
    }
}
