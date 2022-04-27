using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learning.Models
{
    public class CourseViewModel
    {
        public IEnumerable<Course> CourseIndex { get; set; }
        public Course CourseCreate { get; set; }
    }
}
    
