using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IExamService
    {
        List<Exam> GetAll();

        List<Exam> GetByCategories();
        List<Exam> GetAllByCategoryId(int id);

        Exam GetById(int examId);

        void Add(Exam exam);
        void Update(Exam exam, int examId);
        void Delete(int examId);


    }
}
