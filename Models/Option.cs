using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Learning.Models
{
    public class Option
    {
        public int Id { get; set; }
        [Display(Name="Question Option")]
        public string Opt { get; set; }
        public int QuestionId { get; set; }
    }
}