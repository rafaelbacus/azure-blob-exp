using AzureBlobStorageExp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AzureBlobStorageExp.Controllers
{
    public class FilesController : Controller
    {
        private readonly IFileService _fileService;

        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(List<IFormFile> files)
        {
            foreach (var file in files)
            {
                _fileService.SetFileName(file.FileName);
                _fileService.SetStream(file.OpenReadStream());
                _fileService.Create();
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
