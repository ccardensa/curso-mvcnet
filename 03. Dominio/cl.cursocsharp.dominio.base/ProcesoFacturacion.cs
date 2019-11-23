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
        public bool ActualizarFactura(Factura entity)
        {
            
            _repoFactura.Add(entity);
            return _repoFactura.UnitOfWork.SaveChanges();
            
        }
        public Factura BuscarFactura(int id)
        {
            return _repoFactura.Get(x => x.IdFactura == id).FirstOrDefault();            
        }
        public void CrearFactura()
        {
            var dummyFactura = new Factura();
            dummyFactura.Numero = new Random(29).Next(3433).ToString();
            dummyFactura.FechaEmision = DateTime.Now.ToShortDateString();
            this._repoFactura.Add(dummyFactura);
            this._repoFactura.UnitOfWork.SaveChanges();
            var id = dummyFactura.IdFactura;
        }
        public void EliminarFactura(Factura entity)
        {
            var entidad = BuscarFactura(entity.IdFactura);
            _repoFactura.Delete(entidad);
            _repoFactura.UnitOfWork.SaveChanges();
        }
    }
}
