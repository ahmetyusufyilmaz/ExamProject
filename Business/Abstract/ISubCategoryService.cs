using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISubCategoryService
    {
            
        List<SubCategory> GetByCategories();
        SubCategory GetById(int subCategoryId);
        void Add(SubCategory subCategory);

        void Update(SubCategory subCategory, int subCategoryId);
        void Delete(int subCategoryId);

    

}
}
