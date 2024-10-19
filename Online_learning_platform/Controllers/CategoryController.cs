using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_learning_platform.Data;
using Online_learning_platform.Models;
using Online_learning_platform.ViewModels;

namespace Online_learning_platform.Controllers
{
   
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           var categories = _context.Categories.ToList();
         
            return View(categories);
        }

        public IActionResult CategoryCourse(int ID)
        {
            var item = _context.Categories.Find(ID);
            var courses_list = _context.Courses.Where( c=>c.CategoryId == ID).Include(c =>c.Trainer). ToList();

            CategoryViewModel model = new CategoryViewModel()
            {
                category = item,
                courses = courses_list,
            };
            return View(model);
        }
    }
}
