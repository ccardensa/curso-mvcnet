using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class DetalleDto
    {
        public string Articulo { get; set; }
        [Display(Description = "Cantidad Productos")]
        public string Cantidad { get; set; }
        public string Precio { get; set; }
    }
}