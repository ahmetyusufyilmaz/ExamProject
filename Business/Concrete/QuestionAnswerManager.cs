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
    public class QuestionAnswerManager : IQuestionAnswerService
    {

        IQuestionAnswerRepository _questionAnswerRepository;

        public QuestionAnswerManager(IQuestionAnswerRepository questionAnswerRepository)
        {
            _questionAnswerRepository = questionAnswerRepository;
        }

        public void Add(QuestionAnswer questionAnswer)
        {
            _questionAnswerRepository.Add(questionAnswer);
        }

        public void Delete(int questionAnswerId)
        {
            var questionAnswer = _questionAnswerRepository.Get(c => c.QuestionAnswerId == questionAnswerId);
            _questionAnswerRepository.Delete(questionAnswer);
        }

        public List<QuestionAnswer> GetAll()
        {
            return _questionAnswerRepository.GetAll();
        }

        public QuestionAnswer GetById(int questionAnswerId)
        {
            return _questionAnswerRepository.Get(c => c.QuestionAnswerId == questionAnswerId);
        }

        public void Update(QuestionAnswer questionAnswer, int questionAnswerId)
        {
            _questionAnswerRepository.Update(questionAnswer);
        }
    }
}
