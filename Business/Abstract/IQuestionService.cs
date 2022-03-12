using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IQuestionService
    {
        List<Question> GetAll();
        Question GetById(int questionId);
        void Add(Question question);

        void Update(Question question, int questionId);
        void Delete(int questionId);

    }
}
