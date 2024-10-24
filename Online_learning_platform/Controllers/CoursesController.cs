using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_learning_platform.Data;
using Online_learning_platform.Models;

namespace Online_learning_platform.Controllers
{

    public class CoursesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public CoursesController(UserManager<ApplicationUser> usermanger, ApplicationDbContext context)
        {
            _context = context;
            _userManager = usermanger;
        }
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User); // Get the current user ID

            // Get the IDs of courses that the user has already added
            var userCourseIds = await _context.UserCourses
                                              .Where(uc => uc.ApplicationUserId == userId)
                                              .Select(uc => uc.CoursesId)
                                              .ToListAsync();

            // Get all courses except the ones already added by the user
            var courses = await _context.Courses
                                        .Where(c => !userCourseIds.Contains(c.CoursesId)).Include(t => t.Trainer)
                                        .ToListAsync();

            return View(courses);
        }

        public IActionResult Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return View(new List<Courses>()); // If no search term, return empty result
            }

            var courses = _context.Courses
                .Where(c => c.Name.Contains(query) || c.Description.Contains(query)).Include(t => t.Trainer)
                .ToList();

            return View(courses);

        }



    }
}
