using cl.cursocsharp.dominio.contratos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace cl.cursocsharp.infra.datos.Repo
{
    public class Repository<T> : IRepository<T> where T : class
    {
        IUnitOfWork unitofwork;
        private readonly IDbSet<T> _dbSet;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return this.unitofwork;
            }
        }

        public Repository(IUnitOfWork unitofwork)
        {
            this.unitofwork = unitofwork;
            this._dbSet = unitofwork.Set<T>();
        }

        public virtual T GetByID(object id)
        {
            return unitofwork.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return unitofwork.Set<T>().ToList();
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = unitofwork.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual IEnumerable<T> GetStoreProcedure<T>(string query, params object[] parametros)
        {
            return unitofwork.ExecStoreProcedure<T>(query, parametros);
        }
        public IQueryable<T> GetIncluding<T>(params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            IQueryable<T> query = unitofwork.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        //CRUD
        public virtual bool Insert(T entity)
        {
            unitofwork.Set<T>().Add(entity);
            return unitofwork.SaveChanges();
        }

        public virtual void Add(T entity)
        {

            DbEntityEntry dbEntityEntry = unitofwork.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                _dbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {

            DbEntityEntry dbEntityEntry = unitofwork.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(T entityToDelete)
        {

            DbEntityEntry dbEntityEntry = unitofwork.Entry(entityToDelete);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                _dbSet.Attach(entityToDelete);
                _dbSet.Remove(entityToDelete);
            }
        }

        public virtual void Delete(int id)
        {
            var entity = this.GetByID(id);
            if (entity == null) return; // not found; assume already deleted.

            Delete(entity);
        }

        public virtual void Delete(string id)
        {
            var entity = this.GetByID(id);
            if (entity == null) return; // not found; assume already deleted.

            Delete(entity);
        }
    }
}
