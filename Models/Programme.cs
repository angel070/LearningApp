using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Learning.Models
{
    public class Programme
    {
        
        public int Id { get; set; }

        [Required (ErrorMessage ="Programme Name is Required")] [Display(Name ="Programme Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Programme Code is Required")] [Display(Name ="Programme Code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Programme Description is Required")] [Display(Name ="Description")]
        public string Description { get; set; }
    }

   

}