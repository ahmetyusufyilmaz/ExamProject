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
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public IActionResult Index()
        {
          var result= _questionService.GetAllQuestionWithQuestionAnswers();
            return View(result);
        }


        public ActionResult Details(int id)
        {
            Question question = _questionService.GetById(id);

            return View(question);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Question question)
        {
            if (ModelState.IsValid)
            {
                _questionService.Add(question);
                return RedirectToAction("Index");
            }

            return View(question);
        }

        public ActionResult Edit(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Question question)
        {

            _questionService.Update(question, id);
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

            _questionService.Delete(id);
            return RedirectToAction("Index");

        }
    }
    }

