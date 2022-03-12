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
           return _questionRepository.GetAll();
        }

        public Question GetById(int questionId)
        {
            return _questionRepository.Get(c => c.QuestionId == questionId);
        }

        public void Update(Question question, int questionId)
        {
            _questionRepository.Update(question);
        }
    }

      
    }

