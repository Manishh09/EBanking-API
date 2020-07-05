using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;


namespace EBanking.API.Infrastructure
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {      

        private readonly DbContext _context;
        private DbSet<T> _entities;

        public GenericRepository(DbContext context)
        {
            this._context = context;
            _entities = context.Set<T>();
        }
        public virtual IQueryable<T> Get(Expression<Func<T, bool>> expression)
        {
            return this._entities.Where(expression);
        }
        public virtual IQueryable<T> GetAll()
        {
            return _entities.AsQueryable();
        }
        public virtual void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Add(entity);          
        }
        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _entities.Attach(entity);
            }
            _entities.Remove(entity);       
        }
        public virtual void AddRange(IEnumerable<T> entities)
        {
            _entities.AddRange(entities);
        }

    }
}
