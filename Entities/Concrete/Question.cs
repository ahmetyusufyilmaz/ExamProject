using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public enum QuestionType
    {
        OptionsType = 0,
        DescriptionType = 1
    }
    public class Question : IEntity
    {

        public int QuestionId { get; set; }
        [Required]
    public string QuestionText { get; set; }
    public string CorrectAnswer { get; set; }
    public int ExamId { get; set; }
    public Exam Exam { get; set; }
    public int SubCategoryId { get; set; }
    public virtual SubCategory SubCategory { get; set; }
    public QuestionType QuestionType { get; set; }
    [Required]
    public QuestionAnswer QuestionAnswer { get; set; }
}
}
