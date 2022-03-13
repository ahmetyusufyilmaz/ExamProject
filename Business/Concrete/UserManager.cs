using Business.Abstract;
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

        public User Get()
        {
            throw new NotImplementedException();
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

        public void Update(User user, int userId)
        {
            _userRepository.Update(user);
        }
    }
}
