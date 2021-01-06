using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Planner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IHostEnvironment _environment;

        public FileController(IHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Не удалось загрузить файл");
            }

            string fileName = file.FileName;

            string extension = Path.GetExtension(fileName);

            string[] allowedExtensions = { ".doc", ".docx", ".jpg", ".png", "ppt" };

            if (!allowedExtensions.Contains(extension))
            {
                return BadRequest("Формат файла не поддерживается");
            }

            string newFileName = $"{Guid.NewGuid()}{extension}";

            string filePath = Path.Combine(_environment.ContentRootPath, "wwwroot", "Files", newFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                await file.CopyToAsync(fileStream);
            }

            return Ok($"Files/{newFileName}");
        }
    }
}
