using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class CabeceraDto
    {
        [Required]
        public int IdFactura { get; set; }
        [Required]
        public int IdCliente { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]              
        public int NumeroFactura { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        public List<DetalleDto> Detalle { get; set; }
    }
}