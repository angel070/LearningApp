using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Learning.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string level { get; set; }
        //Foreign Key
        [Required]
        [Display(Name = "Programme")]
        public string ProgrammeId { get; set; }

        //Load courses with their prrogrammes
        public Programme Programme{ get; set; }

    }
}