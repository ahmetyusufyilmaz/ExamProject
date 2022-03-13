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
    public class ExamManager : IExamService
    {
        IExamRepository _examRepository;

        public ExamManager(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        public void Add(Exam exam)
        {
            _examRepository.Add(exam);
        }

        public void Delete(int examId)
        {
            var exam = _examRepository.Get(c => c.ExamId == examId);
            _examRepository.Delete(exam);
        }

        public List<Exam> GetAll()
        {
            return _examRepository.GetAll();
        }

        public List<Exam> GetAllByCategoryId(int id)
        {
            return _examRepository.GetAll(c => c.CategoryId == id).ToList();
        }

        public List<Exam> GetByCategories()
        {
            return _examRepository.GetByCategories();
        }

        public Exam GetById(int examId)
        {
            return _examRepository.Get(c => c.ExamId == examId);
        }

        public void Update(Exam exam, int examId)
        {
            _examRepository.Update(exam);
        }
    }
}
