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
    public class ExamController : Controller
    {
        // GET: ExamController

        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        public IActionResult Index()
        {
            return View(_examService.GetByCategories());
        }

    
        public ActionResult Details(int id)
        {
            Exam category = _examService.GetById(id);

            return View(category);
        }

       
        public ActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Exam exam)
        {
            if (ModelState.IsValid)
            {
                _examService.Add(exam);
                return RedirectToAction("Index");
            }

            return View(exam);
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Exam exam)
        {

            _examService.Update(exam, id);
            return RedirectToAction("Index");


        }

     
        public ActionResult Delete()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            _examService.Delete(id);
            return RedirectToAction("Index");

        }
    }
}
