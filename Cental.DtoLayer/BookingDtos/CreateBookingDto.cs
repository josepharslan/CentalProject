using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.BookingDtos
{
    public class CreateBookingDto
    {
        [Required(ErrorMessage = "Lütfen alış lokasyonu giriniz.")]
        public string PickUpLocation { get; set; }
        [Required(ErrorMessage = "Lütfen teslimat lokasyonu giriniz.")]
        public string DropOffLocation { get; set; }
        [Required(ErrorMessage = "Lütfen tarih seçiniz.")]
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Lütfen tarih seçiniz.")]
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        [Required(ErrorMessage = "Lütfen araç seçiniz.")]
        public int CarId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
