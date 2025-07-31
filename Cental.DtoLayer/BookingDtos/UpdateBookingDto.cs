using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.BookingDtos
{
    public class UpdateBookingDto
    {
        public int BookingId { get; set; }
        public string Status { get; set; }
        public int CarId { get; set; }
    }
}
