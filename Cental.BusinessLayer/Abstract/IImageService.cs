using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Abstract
{
    public interface IImageService
    {
        /// <summary>
        /// Saves an image file to the server and returns the URL of the saved image.
        /// </summary>
        /// <param name="file"></param>
        /// <returns> Return a string value for model's ImageUrl property </returns>
        Task<string> SaveImageAsync(IFormFile file);
    }
}
