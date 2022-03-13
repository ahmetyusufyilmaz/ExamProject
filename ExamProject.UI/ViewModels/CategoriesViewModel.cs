using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamProject.UI.ViewModels
{
    public class CategoriesViewModel
    {
        public Category Category { get; set; }
        public List<SubCategory> SubCategory { get; set; }
    }
}
