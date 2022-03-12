using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamProject.UI.Controllers
{
    public class SubCategoryController : Controller
    {

        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        // GET: SubCategoryController
        public ActionResult Index()
        {
            return View(_subCategoryService.GetByCategories());
        }

        // GET: SubCategoryController/Details/5
        public ActionResult Details(int id)
        {
            SubCategory subCategory = _subCategoryService.GetById(id);

            return View(subCategory);
        }

        // GET: SubCategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubCategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubCategory subCategory)
        {

            if (ModelState.IsValid)
            {
                _subCategoryService.Add(subCategory);
                return RedirectToAction("Index");
            }

            return View(subCategory);
        }

        // GET: SubCategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SubCategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SubCategory subCategory)
        {
            _subCategoryService.Update(subCategory, id);
            return RedirectToAction("Index");
        }

        // GET: SubCategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubCategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SubCategory subCategory)
        {
            _subCategoryService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
