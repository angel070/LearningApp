using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Learning.Models
{
    public class Answer
    {
        public int Id { get; set; }
        [Display(Name="Answer")]
        public string Ans { get; set; }
        public int QuestionId { get; set; }
    }
}