using Business.Abstract;
using Business.ViewModels;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public void Add(User user)
        {
            _userRepository.Add(user);
        }

        public void Delete(int userId)
        {
            var user = _userRepository.Get(c => c.UserId == userId);
            _userRepository.Delete(user);
        }

      

       
        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public List<User> GetByAllExam()
        {
            return _userRepository.GetByAllExam();
        }

        public User GetById(int userId)
        {
            return _userRepository.Get(c => c.UserId == userId);
        }


        public bool Login(LoginViewModel model)
        {

            var user = _userRepository.Get(u => u.UserMail == model.Email);
            if (user is null || user.Password!=model.Password )
            {
                return false;
            }
            return true;
        }

        public bool Register(RegisterViewModel rmodel)
        {
            var user = _userRepository.Get(u => u.UserMail == rmodel.Email);

            if (user is not null)
            {
                return false;
            }

            User newUser = new User
            {
                UserMail=rmodel.Email,
                UserName=rmodel.Username,
                Password=rmodel.Password,
                UserSurname=rmodel.UserSurname
            };

            _userRepository.Add(newUser);

            return true;

        }

        public void Update(User user, int userId)
        {
            _userRepository.Update(user);
        }
    }
}
