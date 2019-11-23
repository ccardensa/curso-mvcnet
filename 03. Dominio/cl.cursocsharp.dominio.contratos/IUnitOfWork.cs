using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cl.cursocsharp.dominio.contratos
{
    public interface IUnitOfWork
    {
        IDbSet<T> Set<T>() where T : class;
        System.Data.Entity.Infrastructure.DbEntityEntry<T> Entry<T>(T entity) where T : class;
        //void Attach<T>() where T: class;
        //void Detach<T>(T entity) where T : class;
        bool SaveChanges();
        IEnumerable<T> ExecStoreProcedure<T>(string query, params object[] parametros);
        //void RefreshAll();
    }
}
