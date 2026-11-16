using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace KASHOP.BLL
{
    public class FileService : IFileService
    {
        private static readonly string[] AllowedExtension = { ".png", ".jpeg", ".webp" ,".jpg" };
        private const long MaxFileSize =2 * 1024 * 1024; //2MB
        private static readonly string ImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Image");
        public async Task<string?> UploadAsync(IFormFile file, CancellationToken cancellationToken = default)
        {
            if (file is null || file.Length == 0 || file.Length > MaxFileSize)
                return null;

            var extension = Path.GetExtension(file.FileName).ToLower();

            if (!AllowedExtension.Contains(extension)) return null;
            
            var fileName = Guid.NewGuid().ToString(); // gddhjduie545121.png

            Directory.CreateDirectory(ImagePath);
            var filePath = Path.Combine(ImagePath, fileName);

            await using var stream = File.Create(filePath);
            await file.CopyToAsync(stream , cancellationToken);

            return fileName;
        }

        public void Delete(string filename)
        {
            var filePath = Path.Combine(ImagePath, filename);
            if(File.Exists(filePath))
               File.Delete(filePath);
        }


    }
}
