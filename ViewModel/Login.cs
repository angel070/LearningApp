using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Learning.ViewModel
{
    public class Login
    {

        [Required(ErrorMessage = "User name is required")]
        [Display(Name = "User Name")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
    }
}