﻿using Microsoft.AspNetCore.Mvc;
using Online_learning_platform.Areas.Admin.Repositores;
using Online_learning_platform.Data;
using Online_learning_platform.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Online_learning_platform.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly CrudRepository<Categories> _crudRepository;
        private readonly IHostingEnvironment _host;
        public CategoryController(CrudRepository<Categories> repo , IHostingEnvironment host)
        {
            _crudRepository = repo;
            _host = host;
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
            string fileName = string.Empty;
            if (model.ClientFile != null)
            {
                string myUpload = Path.Combine(_host.WebRootPath, "images");
                fileName = model.ClientFile.FileName;
                string fullPath = Path.Combine(myUpload, fileName);
                model.ClientFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                model.Img = fileName;
            }

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
              string fileName = string.Empty;
            if (model.ClientFile != null)
            {
                string myUpload = Path.Combine(_host.WebRootPath, "images");
                fileName = model.ClientFile.FileName;
                string fullPath = Path.Combine(myUpload, fileName);
                model.ClientFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                model.Img = fileName;
            }
          _crudRepository.Update(model);
            return RedirectToAction("Index");
        }


    }
}
