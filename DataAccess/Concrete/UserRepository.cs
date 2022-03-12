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
    public class UserRepository : EntityRepositoryBase<User, ExamDbContext>, IUserRepository
    {

    
        public List<User> GetByAllExam()
        {
            using (ExamDbContext context = new ExamDbContext())
            {
                var result = context.Users.Include(u => u.Exams);
                return result.ToList();
            }
        }
    }
}
