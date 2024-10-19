using Microsoft.AspNetCore.Mvc;
using Online_learning_platform.Data;
using Online_learning_platform.Models;
using Online_learning_platform.Repositores;

namespace Online_learning_platform.Controllers
{
    public class LessonController : Controller
    {
        private readonly lessonRepository _LessonRepository;

        public LessonController(lessonRepository repo)
        {
            _LessonRepository = repo;
        }
        public IActionResult Index(int CoursesId)
        {
            var lessons = _LessonRepository.GetLessons_Course(CoursesId);
            return View(lessons);
        }

        public IActionResult Lesson_Details(int Lesson_Id,int CoursesId)
        {
            var lesson = _LessonRepository.GetLesson_Details(Lesson_Id, CoursesId); 
            return View(lesson);
        }
    }
}
