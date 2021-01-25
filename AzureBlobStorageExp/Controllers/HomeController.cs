using AzureBlobStorageExp.Models;
using AzureBlobStorageExp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AzureBlobStorageExp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileService _fileService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IFileService fileService, ILogger<HomeController> logger)
        {
            _fileService = fileService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var files = await _fileService.ListFiles();

            return View(files);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
