using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IQuestionRepository : IEntityRepository<Question>
    {
        List<Question> GetAllQuestionWithQuestionAnswers();
        List<Question> GetQuestionsBySubCategory(int subCategoryId);
        List<Question> GetQuestionsByExam(int examId);
    }
}
