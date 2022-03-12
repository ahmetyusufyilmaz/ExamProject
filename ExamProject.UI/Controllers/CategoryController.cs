using Business.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
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

     
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View(_categoryService.GetAll());
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            Category category = _categoryService.GetById(id);

            return View(category);
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
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

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {

            _categoryService.Update(category, id);
            return RedirectToAction("Index");


        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            _categoryService.Delete(id);
            return RedirectToAction("Index");

        }






    }
}
