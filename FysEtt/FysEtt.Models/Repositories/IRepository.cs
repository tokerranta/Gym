using FysEtt.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FysEtt.Models.Repositories
{
    public interface IRepository<T>
        where T : class, IEntity
    {
        T FindById(int id);
        void Add(T entity);
        void Remove(T entity);
        void Remove(int id);
        IQueryable<T> Items();
        IEnumerable<T> Query(Expression<Func<T, bool>> predicate);
    }
}
