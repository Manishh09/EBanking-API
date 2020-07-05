using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EBanking.API.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> expression);       
        void Insert(T entity);
        void Delete(T entity);
        void AddRange(IEnumerable<T> entities);

    }
}
