using Microsoft.AspNetCore.Mvc;

namespace Online_learning_platform.Controllers
{
    public class MyCoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
