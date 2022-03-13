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
                var result = context.Questions.Include(u => u.QuestionAnswer);
                return result.ToList();
            }
        }

    }
}

