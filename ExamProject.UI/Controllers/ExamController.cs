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

        public IActionResult GetQuestionsByExam(int id)
        {
            return View(_examService.GetQuestionsByExam(id));
        }

       


        public ActionResult Details(int id)
        {
            Exam exam = _examService.GetByCategories().SingleOrDefault(x=>x.ExamId==id);

            return View(exam);
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

        public ActionResult Edit(int id,int _)
        {
            var result = _examService.GetAll().SingleOrDefault(q => q.ExamId == id);
            return View(result);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Exam exam)
        {

            _examService.Update(exam, id);
            return RedirectToAction("Index");


        }

     
        public ActionResult Delete(int id, int _)
        {
            var result = _examService.GetAll().SingleOrDefault(q => q.ExamId == id);
            return View(result);
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
