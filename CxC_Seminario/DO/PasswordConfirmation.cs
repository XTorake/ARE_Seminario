using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CxC_Seminario.DO
{
    public class PasswordConfirmation
    {
        [StringLength(20)]
        public string Contrasena { get; set; }
        [Compare("Contrasena", ErrorMessage = "Las contraseñas no coinciden!")]
        public string ConfirmPassword { get; set; }
    }
}