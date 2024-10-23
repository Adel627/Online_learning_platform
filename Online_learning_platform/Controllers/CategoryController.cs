using Microsoft.AspNetCore.Authorization;
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
        public CategoryController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
           var categories = _categoryRepository.GetCategories();
         
            return View(categories);
        }

        public IActionResult CategoryCourse(int ID)
        {
            var item = _categoryRepository.GetCategory(ID);
            var courses_list = _categoryRepository.Category_Courses(ID);

            CategoryViewModel model = new CategoryViewModel()
            {
                category = item,
                courses = courses_list,
            };
            return View(model);
        }
    }
}
