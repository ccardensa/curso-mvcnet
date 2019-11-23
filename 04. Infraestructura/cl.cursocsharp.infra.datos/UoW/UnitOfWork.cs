using cl.cursocsharp.dominio.contratos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cl.cursocsharp.infra.datos.UoW
{
    
        public class UnitOfWork<T> : IUnitOfWork where T : DbContext, new()
        {
            public UnitOfWork()
            {
                DatabaseContext = new T();
            }

            private T DatabaseContext { get; set; }

            public bool SaveChanges()
            {
                try
                {
                    return DatabaseContext.SaveChanges() == 1 ? true : false;
                }
                catch (DbEntityValidationException e)
                {
                    var newException = e;
                    throw e;
                }

            }

            public IDbSet<T> Set<T>() where T : class
            {
                return DatabaseContext.Set<T>();
            }

            public DbEntityEntry<T> Entry<T>(T entity) where T : class
            {
                return DatabaseContext.Entry<T>(entity);
            }

            public IEnumerable<T> ExecStoreProcedure<T>(string query, params object[] parametros)
            {

                var resultado = DatabaseContext.Database.SqlQuery<T>(query, parametros);

                return resultado;
            }       
    }
}
