using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace ExamProject.UI.Controllers
{
    public class SubCategoryController : Controller
    {

        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        [Authorize(Roles = "Admin,Member")]
        public ActionResult Index()
        {
            return View(_subCategoryService.GetByCategories());
        }

        [Authorize(Roles = "Admin,Member")]
        public IActionResult GetQuestionsBySubCategory(int id)
        {
            return View(_subCategoryService.GetQuestionsBySubCategory(id));
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            SubCategory subCategory = _subCategoryService.GetByCategories().SingleOrDefault(x=>x.SubCategoryId==id);

            return View(subCategory);


        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubCategory subCategory)
        {

            if (ModelState.IsValid)
            {
                _subCategoryService.Add(subCategory);
                return RedirectToAction("Index");
            }

            return View(subCategory);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id,int _)
        {
            var result = _subCategoryService.GetByCategories().SingleOrDefault(q => q.SubCategoryId == id);
            return View(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SubCategory subCategory)
        {
            _subCategoryService.Update(subCategory, id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var result = _subCategoryService.GetByCategories().SingleOrDefault(q => q.SubCategoryId == id);
            return View(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SubCategory subCategory)
        {
            _subCategoryService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
