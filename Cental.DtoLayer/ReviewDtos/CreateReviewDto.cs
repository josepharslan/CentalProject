using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.ReviewDtos
{
    public class CreateReviewDto
    {
        [Required(ErrorMessage = "Lütfen bir puan seçiniz.")]
        public int Rating { get; set; }
        [Required(ErrorMessage = "Yorum alanı boş bırakılamaz.")]
        [StringLength(180, ErrorMessage = "Yorum en fazla 180 karakter olabilir.")]
        public string? Content { get; set; }
        [Required]
        public int CarId { get; set; }
    }
}
