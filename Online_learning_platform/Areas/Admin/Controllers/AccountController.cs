using Microsoft.AspNetCore.Mvc;

namespace Online_learning_platform.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
