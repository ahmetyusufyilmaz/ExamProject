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
    public class SubCategoryRepository:EntityRepositoryBase<SubCategory, ExamDbContext>, ISubCategoryRepository
    {

        public List<SubCategory> GetByCategories()
        {
            using (ExamDbContext context = new ExamDbContext())
            {
                var result = context.SubCategories.Include(u => u.Category);
                return result.ToList();
            }
        }

    }
}
