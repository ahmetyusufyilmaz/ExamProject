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
    public class CategoryManager : ICategoryService
    {
        ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Add(Category category)
        {
            _categoryRepository.Add(category);
        }

        public void Delete(int categoryId)
        {
            var category = _categoryRepository.Get(c=>c.CategoryId== categoryId);
            _categoryRepository.Delete(category);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        // Select * from Categories where CategoryId=3
        public Category GetById(int categoryId)
        {
            return _categoryRepository.Get(c => c.CategoryId == categoryId);
        }

        public void Update(Category category, int categoryId)
        {
            category.CategoryId = categoryId;
            _categoryRepository.Update(category);
        }
    }
}
