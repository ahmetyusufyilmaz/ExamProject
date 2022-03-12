using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : IEntity
    {

        public int UserId { get; set; }
        [StringLength(20)]
        public string UserName { get; set; }
        [StringLength(20)]
        public string UserSurname { get; set; }
        [StringLength(50)]
        public string UserMail { get; set; }
        public ICollection<Exam> Exams { get; set; }

    }
}
