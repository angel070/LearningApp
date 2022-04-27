using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Learning.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string FilePath { get; set; }
        public string Description { get; set; }
 
        [Display(Name="Topic")]
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
       
    }
}