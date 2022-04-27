using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Learning.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Quiz Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Question")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    
    }
}