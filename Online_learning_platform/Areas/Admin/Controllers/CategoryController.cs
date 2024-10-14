using Microsoft.AspNetCore.Mvc;
using Online_learning_platform.Areas.Admin.Repositores;
using Online_learning_platform.Data;
using Online_learning_platform.Models;

namespace Online_learning_platform.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly CrudRepository<Categories> _crudRepository;
        public CategoryController(CrudRepository<Categories> repo)
        {
            _crudRepository = repo;
        }
        public IActionResult Index()
        {
            var Categories_list = _crudRepository.GetAll().ToList();
        
            return View(Categories_list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Categories model)
        {
           _crudRepository.creat(model);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
         _crudRepository.Delete(id);
          
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var category = _crudRepository.FindById(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Categories model)
        {
          _crudRepository.Update(model);
            return RedirectToAction("Index");
        }


    }
}
