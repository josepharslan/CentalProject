using Cental.BusinessLayer.Abstract;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class ImageService : IImageService
    {
        public async Task<string> SaveImageAsync(IFormFile file)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (extension != ".jpg" && extension != ".png" && extension != ".jpeg")
            {
                throw new ValidationException("Dosya formatı jpg, png veya jpeg olmalıdır.");
            }
            var imageFolder = Path.Combine(currentDirectory, "wwwroot/images");
            if (!Directory.Exists(imageFolder))
            {
                Directory.CreateDirectory(imageFolder);
            }
            var imageName = Guid.NewGuid() + extension;
            var saveLocation = Path.Combine(imageFolder, imageName);

            var stream = new FileStream(saveLocation, FileMode.Create);
            await file.CopyToAsync(stream);

            return "/images/" + imageName;
        }
    }
}
