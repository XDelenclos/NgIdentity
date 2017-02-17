using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NgCooking.Tools
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {

        }

        [Required]
        [Display(Name = "Identifiant (email)")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

    }

}
