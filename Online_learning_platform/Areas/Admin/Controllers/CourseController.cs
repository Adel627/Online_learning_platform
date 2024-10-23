using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_learning_platform.Areas.Admin.Repositores;
using Online_learning_platform.Areas.Admin.ViewModels;
using Online_learning_platform.Data;
using Online_learning_platform.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace Online_learning_platform.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly CourseRepository _courseRepository;
        private readonly IHostingEnvironment _host;


        public CourseController(CourseRepository repo, IHostingEnvironment host)
        {
            _courseRepository = repo;
            _host = host;
       
        }

        public IActionResult Index()
        {        
            var courses = _courseRepository.GetAll();
            return View(courses);
        }

        public IActionResult Create()
        {
            var categories = _courseRepository.Get_SelectionListcategories();
          

            var trainers = _courseRepository.Get_SelectionListtrainers();
         

            var model = new CourseViewModel
            {
                Categores = categories,
                Trainers = trainers
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Create(CourseViewModel model)
        {
            string fileName = string.Empty;
            if (model.Courses.ClientFile != null)
            {
                string myUpload = Path.Combine(_host.WebRootPath, "images");
                fileName = model.Courses.ClientFile.FileName;
                string fullPath = Path.Combine(myUpload, fileName);
                model.Courses.ClientFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                model.Courses.Img = fileName;
            }

            _courseRepository.create(model.Courses);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            _courseRepository.Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int CoursesId)
        {
            var coursefound = _courseRepository.FindById(CoursesId);
            return View(coursefound);
        }
        [HttpPost]
        public IActionResult Edit(Courses model)
        {
            string fileName = string.Empty;
            if (model.ClientFile != null)
            {
                string myUpload = Path.Combine(_host.WebRootPath, "images");
                fileName = model.ClientFile.FileName;
                string fullPath = Path.Combine(myUpload, fileName);
                model.ClientFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                model.Img = fileName;
            }

            _courseRepository.Update(model);
            return RedirectToAction("Index");
        }
    }
}
