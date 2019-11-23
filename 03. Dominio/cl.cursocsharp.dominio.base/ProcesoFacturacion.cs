using cl.cursocsharp.dominio.contratos;
using cl.cursocsharp.dominio.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cl.cursocsharp.dominio
{
    public class ProcesoFacturacion : IProcesoFacturacion
    {
        readonly IRepository<Factura> _repoFactura;
        public ProcesoFacturacion(IRepository<Factura> _repoFactura)
        {
            this._repoFactura = _repoFactura;
        }

        public void GuardarFactura()
        {
            var dummyFactura = new Factura();
            dummyFactura.Numero = "200";
            dummyFactura.FechaEmision = DateTime.Now.ToShortDateString();
            this._repoFactura.Add(dummyFactura);
            this._repoFactura.UnitOfWork.SaveChanges();
            var id = dummyFactura.IdFactura;
        }
    }
}
