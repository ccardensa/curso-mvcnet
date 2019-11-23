using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace cl.cursocsharp.dominio.contratos
{
    public interface IRepository<TEntity>
    {
        IUnitOfWork UnitOfWork { get; }

        TEntity GetByID(object id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        IQueryable<T> GetIncluding<T>(params Expression<Func<T, object>>[] includeProperties) where T : class;
        IEnumerable<T> GetStoreProcedure<T>(string query, params object[] parametros);
        bool Insert(TEntity entity);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entityToDelete);
        void Delete(int id);
        void Delete(string id);
    }
}
