using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.ReviewDtos
{
    public class ResultReviewDto
    {
        public int Rating { get; set; }
        public string Content { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
    }
}
