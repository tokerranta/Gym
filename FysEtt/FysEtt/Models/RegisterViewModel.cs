using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FysEtt.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required, Compare("Password", ErrorMessage = "Lösenorden matchar inte!")]
        public string RepeatedPassword { get; set; }

        public string ReturnUrl { get; set; }
    }
}