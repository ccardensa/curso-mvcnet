using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class FacturaDto
    {
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }
        public int NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
    }
}