using Microsoft.AspNetCore.Mvc;

namespace Online_learning_platform.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class TrainerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
