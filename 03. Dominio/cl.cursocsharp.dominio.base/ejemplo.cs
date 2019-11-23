using cl.cursocsharp.dominio.entidades;
using cl.cursocsharp.infra.datos;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cl.cursocsharp.dominio.contratos;

namespace cl.cursocsharp.dominio
{
    public class ejemplo : IEjemplo
    {

        public void TestDb()
        {           
            using (var db = new Entities())
            {                
                var dummyFactura = new Factura();
                dummyFactura.Numero = "200";                
                db.Facturas.Add(dummyFactura);
                
                db.SaveChanges();
                var id = dummyFactura.IdFactura;
            }
        }

        public void TestDbGeneric<T>(T entidad)
        {
            using (var db = new Entities())
            {                
                //db.Set<T>().Add(entidad);
                db.SaveChanges();
            }
        }
    }
}
