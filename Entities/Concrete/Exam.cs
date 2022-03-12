using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Exam : IEntity
    {
        public int ExamId { get; set; }
        [Required]
        [StringLength(30)]
        public string ExamName { get; set; }
        [Required]
        public short Duration { get; set; }
        public short NumberOfQuestions { get; set; }
        public string Description { get; set; }
        public int SuccessGrade { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } = false;
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<Question> Questions { get; set; }
        
        public ICollection<User> Users { get; set; }

    }
}
