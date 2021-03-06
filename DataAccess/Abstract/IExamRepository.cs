using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IExamRepository: IEntityRepository<Exam>
    {
        List<Exam> GetByCategories();
        List<Question> GetQuestionsByExam(int examId);
    }
}
