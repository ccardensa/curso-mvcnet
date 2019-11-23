using cl.cursocsharp.dominio.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cl.cursocsharp.dominio.contratos
{
    public interface IProcesoFacturacion
    {
        void CrearFactura();
        void EliminarFactura(Factura entity);
        bool ActualizarFactura(Factura entity);
        Factura BuscarFactura(int id);
    }
}
