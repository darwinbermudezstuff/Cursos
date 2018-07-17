using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Storage.Models.Login
{
    public class LoginViewModels
    {
        [Required]
        public string Correo { get; set; }

        [Required]
        public string Password { get; set; }
    }
}