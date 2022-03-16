using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin,Member")]
        public IActionResult Index()
        {
            return View(_examService.GetByCategories());
        }

        [Authorize(Roles = "Admin,Member")]
        public IActionResult GetQuestionsByExam(int id)
        {
            return View(_examService.GetQuestionsByExam(id));
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            Exam exam = _examService.GetByCategories().SingleOrDefault(x=>x.ExamId==id);

            return View(exam);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id,int _)
        {
            var result = _examService.GetAll().SingleOrDefault(q => q.ExamId == id);
            return View(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Exam exam)
        {

            _examService.Update(exam, id);
            return RedirectToAction("Index");


        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id, int _)
        {
            var result = _examService.GetAll().SingleOrDefault(q => q.ExamId == id);
            return View(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            _examService.Delete(id);
            return RedirectToAction("Index");

        }
    }
}
