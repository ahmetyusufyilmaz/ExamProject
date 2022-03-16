using Business.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using ExamProject.UI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ExamProject.UI.Controllers
{

    public class CategoryController : Controller
    {

        private readonly ISubCategoryService _subCategoryService;
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService,ISubCategoryService subCategoryService)
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
        }
        [Authorize(Roles = "Admin,Member")]
        public IActionResult Index()
        {
            return View(_categoryService.GetAll());
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            CategoriesViewModel model = new CategoriesViewModel();
            model.Category = _categoryService.GetAll().SingleOrDefault(x=>x.CategoryId==id);
            model.SubCategory = _subCategoryService.GetByCategories().Where(x=>x.CategoryId==id).ToList();
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Add(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id, int _) 
        {
            var result = _categoryService.GetAll().SingleOrDefault(q => q.CategoryId == id);
            return View(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {
            _categoryService.Update(category, id);
            return RedirectToAction("Index");

        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id, int _)
        {
            var result = _categoryService.GetAll().SingleOrDefault(q => q.CategoryId == id);
            return View(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            _categoryService.Delete(id);
            return RedirectToAction("Index");

        }

    }
}
