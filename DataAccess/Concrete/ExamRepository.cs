using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ExamRepository: EntityRepositoryBase<Exam, ExamDbContext>, IExamRepository
    {
        public List<Exam> GetByCategories()
        {
            using (ExamDbContext context = new ExamDbContext())
            {
                var result = context.Exams.Include(u => u.Category);
                return result.ToList();
            }
        }


        public List<Question> GetQuestionsByExam(int examId)
        {
            using (ExamDbContext context = new ExamDbContext())
            {
                var result = context.Questions.Where(q=>q.ExamId==examId);
                return result.ToList();
            }
        }



    }
}
