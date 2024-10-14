using Microsoft.AspNetCore.Mvc;

namespace Online_learning_platform.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
