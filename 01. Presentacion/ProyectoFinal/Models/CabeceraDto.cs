using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class CabeceraDto
    {
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }
        public int NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public List<DetalleDto> Detalle { get; set; }
    }
}