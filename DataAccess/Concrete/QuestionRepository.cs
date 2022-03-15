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
    public class QuestionRepository : EntityRepositoryBase<Question, ExamDbContext>, IQuestionRepository
    {

        public List<Question> GetAllQuestionWithQuestionAnswers()
        {
            using (ExamDbContext context = new ExamDbContext())
            {
                var result = context.Questions.Include(u => u.QuestionAnswer).Include(u => u.Exam).Include(u => u.SubCategory);
                return result.ToList();
            }
        }

        public List<Question> GetQuestionsBySubCategory(int subCategoryId)
        {
            using (ExamDbContext context = new ExamDbContext())
            {
                var result = context.Questions.Where(q => q.SubCategoryId == subCategoryId).Include(q => q.Exam).Include(q => q.SubCategory);
                return result.ToList();
            }
        }

         public List<Question> GetQuestionsByExam(int examId)
        {
            using (ExamDbContext context = new ExamDbContext())
            {
                var result = context.Questions.Where(q=>q.ExamId==examId).Include(q=>q.Exam).Include(q=>q.SubCategory);
                return result.ToList();
            }
        }





    }
}

