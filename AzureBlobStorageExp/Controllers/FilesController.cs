using AzureBlobStorageExp.Models;
using AzureBlobStorageExp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureBlobStorageExp.Controllers
{
    public class FilesController : Controller
    {
        private readonly IFileUploader _fileUploader;

        public FilesController(IFileUploader fileUploader)
        {
            _fileUploader = fileUploader;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(List<IFormFile> files)
        {
            foreach (var file in files)
            {
                using (var azureFile = new AzureFile(file.FileName, file.OpenReadStream()))
                {
                    await _fileUploader.Upload(azureFile);
                }
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
