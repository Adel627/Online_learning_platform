using Microsoft.AspNetCore.Mvc;
using Online_learning_platform.Data;
using Online_learning_platform.Models;
using System.Diagnostics;

namespace Online_learning_platform.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {

            _logger = logger;
            _context = context;
        }
       
        public IActionResult Index()
        {
             //  return RedirectToAction("Index", "Home", new { area = "Admin" });
               return View();
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

