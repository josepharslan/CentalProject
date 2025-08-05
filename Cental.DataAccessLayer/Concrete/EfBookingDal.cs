using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.DataAccessLayer.Repositories;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Concrete
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(CentalContext context) : base(context)
        {
        }

        public List<Booking> GetBookingsByUserId(int userId)
        {
            return _context.Bookings.Where(x => x.AppUserId == userId).ToList();
        }
    }
}
