using Business.ViewModels;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IUserService
    {

        List<User> GetAll();
        User GetById(int userId);
        List<User> GetByAllExam();
        bool Login(LoginViewModel model);
        bool Register(RegisterViewModel rmodel);
        void Add(User user);
        void Update(User user, int userId);
        void Delete(int userId);
    }
}
