using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_learning_platform.Data;

namespace Online_learning_platform.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var courses_list = _context.Courses.Include(t =>t.Trainer).ToList();
            
            return View(courses_list);
        }
     
    }
}
