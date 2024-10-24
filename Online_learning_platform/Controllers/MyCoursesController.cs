using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_learning_platform.Data;
using Online_learning_platform.Models;
using Online_learning_platform.Repositores;

namespace Online_learning_platform.Controllers
{
    [Authorize]
    public class MyCoursesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        public MyCoursesController(UserManager<ApplicationUser> usermanger,ApplicationDbContext context)
        {
            _userManager = usermanger;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var courses = await _context.UserCourses
                              .Where(uc => uc.ApplicationUserId == userId)
                              .Include(c => c.Courses)
                               .ThenInclude(c => c.Trainer)
                              .Select(uc => uc.Courses)
                              .ToListAsync();

            return View(courses);
        }

        [HttpPost]
        public async Task<IActionResult> AddToMyCourses(int courseId)
        {
            var userId = _userManager.GetUserId(User); 
            var userCourse = new UserCourses
            {
                ApplicationUserId = userId,
                CoursesId = courseId
            };

            _context.UserCourses.Add(userCourse);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> DeleteFromMyCourses(int courseId)
        {
            var userId = _userManager.GetUserId(User); // Get the current user ID
            var userCourse = await _context.UserCourses
                                .FirstOrDefaultAsync(uc => uc.ApplicationUserId == userId && uc.CoursesId == courseId);

            if (userCourse != null)
            {
                _context.UserCourses.Remove(userCourse);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index"); // Redirect to My Courses page
        }

    }
}
