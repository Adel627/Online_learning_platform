using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_learning_platform.Models;
using Online_learning_platform.ViewModels;

namespace Online_learning_platform.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> user, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = user;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName=model.Username
                };
                var result = _userManager.CreateAsync(user, model.Password).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByEmailAsync(model.Email).Result;
                if (user is not null)
                {
                    if (_userManager.CheckPasswordAsync(user, model.Password).Result)
                    {
                        var res = _signInManager.PasswordSignInAsync(user, model.Password, false, false).Result;
                        if (res.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }

            }
            ModelState.AddModelError(string.Empty, "Incorrect email or password");
            return View();
        }
    }
}
