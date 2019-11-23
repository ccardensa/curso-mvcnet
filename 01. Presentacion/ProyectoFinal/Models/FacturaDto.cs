using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class FacturaDto
    {
        public CabeceraDto CabeceraDto { get; set; }
        public DetalleDto DetalleDto { get; set; }
    }
}