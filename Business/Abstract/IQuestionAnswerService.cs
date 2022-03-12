using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IQuestionAnswerService
    {
        List<QuestionAnswer> GetAll();
        QuestionAnswer GetById(int questionAnswerId);
        void Add(QuestionAnswer questionAnswer);
        void Update(QuestionAnswer questionAnswer, int questionAnswerId);
        void Delete(int questionAnswerId);

    }
}
