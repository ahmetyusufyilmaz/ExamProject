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
    public class SubCategoryManager : ISubCategoryService
    {
        ISubCategoryRepository _subCategoryRepository;

        public SubCategoryManager(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public void Add(SubCategory subCategory)
        {
            _subCategoryRepository.Add(subCategory);
        }

        public void Delete(int subCategoryId)
        {
            var question = _subCategoryRepository.Get(c => c.SubCategoryId == subCategoryId);
            _subCategoryRepository.Delete(question);
        }

        public List<SubCategory> GetByCategories()
        {

            return _subCategoryRepository.GetByCategories();
        }

        public SubCategory GetById(int subCategoryId)
        {
            return _subCategoryRepository.Get(c => c.SubCategoryId == subCategoryId);
        }

        public List<Question> GetQuestionsBySubCategory(int subCategoryId)
        {
            return _subCategoryRepository.GetQuestionsBySubCategory(subCategoryId);
        }

        public void Update(SubCategory subCategory, int subCategoryId)
        {
            _subCategoryRepository.Update(subCategory);
        }
    }
}
