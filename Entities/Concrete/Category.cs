using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        [Required]
        [StringLength(20)]
        public string CategoryName { get; set; }
        public ICollection<SubCategory> SubCategories { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Exam> Exams { get; set; }

    }
}
