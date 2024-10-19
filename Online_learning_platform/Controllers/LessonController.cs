using Microsoft.AspNetCore.Mvc;
using Online_learning_platform.Data;
using Online_learning_platform.Models;

namespace Online_learning_platform.Controllers
{
    public class LessonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LessonController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int CoursesId)
        {
            var lessons = _context.lesson.Where(c=>c.CoursesId == CoursesId).ToList();
            return View(lessons);
        }

        public IActionResult Lesson_Details(int Lesson_Id,int CoursesId)
        {
            var lesson = _context.lesson.Find(Lesson_Id, CoursesId); 
            return View(lesson);
        }
    }
}
