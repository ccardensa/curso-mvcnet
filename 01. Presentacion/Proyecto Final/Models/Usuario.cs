using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrimeraClase.Models
{
    public class Usuario
    {
        [Required] 
        public string Nombre { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Superaste el largo")]
        public string Apellido { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}