using Microsoft.AspNetCore.Mvc;
using Online_learning_platform.Areas.Admin.Repositores;
using Online_learning_platform.Areas.Admin.ViewModels;
using Online_learning_platform.Data;
using Online_learning_platform.Models;

namespace Online_learning_platform.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class LessonsController : Controller
    {
        private readonly LessonRepository _lessonRepository;
        public LessonsController(LessonRepository context)
        {
            _lessonRepository= context;            
        }
        public IActionResult Index(int id)
        {
            var res = _lessonRepository.GetLessons_Course(id);
            return View(res);
        }

        public IActionResult Details(int lessonId,int courseId) 
        {
            var lessonDetails = _lessonRepository.DetailsLesson(lessonId,courseId);
            return View(lessonDetails);
        }

        public IActionResult Create(int id) 
        {
           Lesson model = new Lesson()
           {
               CoursesId = id,
           };
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(Lesson model)
        {
           
            _lessonRepository.create(model);
            return RedirectToAction("Index", new {id=model.CoursesId});
        }

        public IActionResult Delete(int lessonId, int courseId)
        {
           _lessonRepository.Delete(lessonId, courseId);    
            return RedirectToAction("Index", new { id = courseId});
        }

    }
}
