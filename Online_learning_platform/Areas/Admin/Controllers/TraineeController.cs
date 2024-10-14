using Microsoft.AspNetCore.Mvc;

namespace Online_learning_platform.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class TraineeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
