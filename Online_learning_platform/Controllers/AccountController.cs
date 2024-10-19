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
        private readonly RoleManager<IdentityRole> _roleManager; // Add RoleManager

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager; // Initialize RoleManager
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Username
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Check if the role exists
                    if (!await _roleManager.RoleExistsAsync("User"))
                    {
                        // Create the role if it doesn't exist
                        await _roleManager.CreateAsync(new IdentityRole("User"));
                    }

                    // Assign the role to the user
                    await _userManager.AddToRoleAsync(user, "User");

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
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    if (await _userManager.CheckPasswordAsync(user, model.Password))
                    {
                        var res = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                        if (res.Succeeded)
                        {
                            // Check if the user has the "Admin" role
                            if (await _userManager.IsInRoleAsync(user, "Admin"))
                            {
                                // Redirect to a specific view for Admin
                                return RedirectToAction("Index", "Home", new { area = "Admin" });
                            }

                            // If not an admin, redirect to the default home page
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }

                ModelState.AddModelError(string.Empty, "Incorrect email or password");
            }

            return View();
        }

    }
}
