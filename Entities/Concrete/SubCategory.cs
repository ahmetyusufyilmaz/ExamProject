using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class SubCategory:IEntity
    {
        public int SubCategoryId { get; set; }
        [Required]
        [StringLength(20)]
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
