using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_learning_platform.Data;
using Online_learning_platform.Models;
using Online_learning_platform.Repositores;
using Online_learning_platform.ViewModels;

namespace Online_learning_platform.Controllers
{
    
   
    public class CategoryController : Controller
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        public CategoryController(CategoryRepository categoryRepository,UserManager<ApplicationUser> userManager,ApplicationDbContext context)
        {
            _categoryRepository = categoryRepository;
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index()
        {
           var categories = _categoryRepository.GetCategories();
         
            return View(categories);
        }
        public async Task<IActionResult> CategoryCourse(int ID)
        {
            var item = _categoryRepository.GetCategory(ID);

            var userId = _userManager.GetUserId(User); // Get the current user ID

            // Get the IDs of courses that the user has already added
            var userCourseIds = await _context.UserCourses
                                              .Where(uc => uc.ApplicationUserId == userId)
                                              .Select(uc => uc.CoursesId)
                                              .ToListAsync();

            // Get all courses in same category  except the ones already added by the user
            var courses = await _context.Courses
                                        .Where(c => c.CategoryId == ID && !userCourseIds.Contains(c.CoursesId)).Include(t => t.Trainer)
                                        .ToListAsync();

            CategoryViewModel model = new CategoryViewModel()
            {
                category = item,
                courses = courses,
            };

            return View(model);
        }
    }
}
