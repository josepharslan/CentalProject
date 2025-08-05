using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.TestimonialDtos
{
    public class CreateTestimonialDto
    {
        public string ImageUrl { get; set; } = string.Empty;
        [Required] public string Name { get; set; } = "";
        [Required] public string Title { get; set; } = "";
        [Range(1, 5)] public int ReviewStar { get; set; }
        public string? Comment { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
