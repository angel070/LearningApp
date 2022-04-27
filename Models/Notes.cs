using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Learning.Models
{
    public class Notes
    {
        public int Id { get; set; }
        //Foreign Key
        [Required]
        [Display(Name="Topics")]
        public int TopicId { get; set; }
        //Load Notes with their Topics
        [Required]
        [Display(Name = "Notes")]
        public string Note { get; set; }

        public virtual Topic Topic {get; set;}
    }
}