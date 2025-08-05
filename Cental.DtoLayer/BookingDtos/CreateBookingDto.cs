using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.BookingDtos
{
    public class CreateBookingDto
    {
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public int CarId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
