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

    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        private static int _score;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
            int score = 0;
            _score = score;
        }
        [Authorize(Roles = "Admin,Member")]
        public IActionResult Index()
        {
          var result= _questionService.GetAllQuestionWithQuestionAnswers();
            return View(result);
        }

        [Authorize(Roles = "Admin,Member")]
        public IActionResult GetQuestionsBySubCategory(int id)
        {
            return View(_questionService.GetQuestionsBySubCategory(id));
        }
        [Authorize(Roles = "Admin,Member,")]
        public IActionResult GetQuestionsByExam(int id)
        {
            return View(_questionService.GetQuestionsByExam(id));
        }


        public IActionResult GetQuestionsWithAnswers(int id,string answer)
        {
            var questionOld = _questionService.GetById(id);
            if (answer != null && questionOld.CorrectAnswer == answer)
            {
                _score += 1;
            }

            var questionLast = _questionService.GetAll().OrderByDescending(q => q.QuestionId).Take(1).SingleOrDefault();

            if (questionLast.QuestionId == id)
            {
                questionOld = _questionService.GetById(id);
                ViewData["lastquestion"] = id;
                return View(questionOld);
            }

            var question = _questionService.GetAllQuestionWithQuestionAnswers().Where(x=>x.ExamId == 1)
                .FirstOrDefault(x=>x.QuestionId > id);

             return View(question);
        }


        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            Question question = _questionService.GetAllQuestionWithQuestionAnswers().SingleOrDefault(x=>x.QuestionId==id);

            return View(question);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id, int _)
        {
            var result = _questionService.GetAllQuestionWithQuestionAnswers().SingleOrDefault(q => q.QuestionId == id);
            return View(result);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Question question)
        {

            _questionService.Update(question, id);
            return RedirectToAction("Index");


        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id,int _)
        {
           var result= _questionService.GetAllQuestionWithQuestionAnswers().SingleOrDefault(q=>q.QuestionId==id);
            return View(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            _questionService.Delete(id);
            return RedirectToAction("Index");

        }
    }
    }

