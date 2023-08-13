using App.API.Abstract;
using App.API.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        public FileController(IFileService fileService, IWebHostEnvironment environment)
        {
            FileService = fileService;
            Environment = environment;
        }

        public IFileService FileService { get; }
        public IWebHostEnvironment Environment { get; }

        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            var result = FileService.SaveImage(file);

            return result.Item1 == 0 ? BadRequest() : Ok(result.Item2);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get([FromQuery]string fileName)
        {
            // Projenin kök dizinine erişim sağlar.
            var contentPath = Environment.ContentRootPath;

            // Resimleri saklamak için "Uploads" adında bir klasör yolu oluştur.
            var path = Path.Combine(contentPath, "Uploads");

            var fileFullPath = Path.Combine(path, fileName);

            if (!System.IO.File.Exists(fileFullPath))
            {
                return NotFound();
            }

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(fileFullPath, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            return File(Path.Combine("Uploads", fileName), contentType);
        }


    }
}
