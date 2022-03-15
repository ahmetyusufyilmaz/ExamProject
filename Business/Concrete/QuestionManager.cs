using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class QuestionManager : IQuestionService
    {
        IQuestionRepository _questionRepository;

        public QuestionManager(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }


        public void Add(Question question)
        {
            _questionRepository.Add(question);
        }

        public void Delete(int questionId)
        {
            var question = _questionRepository.Get(c => c.QuestionId == questionId);
            _questionRepository.Delete(question);
        }

        public List<Question> GetAll()
        {
          var result=  _questionRepository.GetAll();
            return result;
        }

        public List<Question> GetAllQuestionWithQuestionAnswers()
        {
            return _questionRepository.GetAllQuestionWithQuestionAnswers();
        }

        public Question GetById(int questionId)
        {
            return _questionRepository.Get(c => c.QuestionId == questionId);
        }

        public List<Question> GetQuestionsByExam(int examId)
        {
           
                return _questionRepository.GetQuestionsByExam(examId);
            
        }

        public List<Question> GetQuestionsBySubCategory(int subCategoryId)
        {
            return _questionRepository.GetQuestionsBySubCategory(subCategoryId);
        }

        public void Update(Question question, int questionId)
        {
            _questionRepository.Update(question);
        }
    }

      
    }

