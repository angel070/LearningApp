using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Learning.Models
{
    public class Topic
    {

        public int Id{get; set;}
        public string Name { get; set; }
        public string Code { get; set; }
        public string subtopic { get; set; }
        //Foreign Key
        [Display(Name = "Course")]
        public string CourseId { get; set; }

        //Load courses with their prrogrammes
        public Course Course { get; set; }
    }
}