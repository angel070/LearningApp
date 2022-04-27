using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Learning.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Display(Name="Question")]
        public string Quest { get; set; }      
        [Display(Name ="Reason(option)")]
        public string Reason { get; set; }      
        [Display(Name = "Topic")]
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}