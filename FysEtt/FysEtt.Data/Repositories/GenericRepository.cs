using FysEtt.Data.Context;
using FysEtt.Models.Entities;
using FysEtt.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FysEtt.Data.Repositories
{
    public class GenericRepository<T> : IRepository<T>
        where T : class, IEntity
    {

        protected readonly FysettContext _context;

        public GenericRepository(FysettContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            _context = context;
        }

        public T FindById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Remove(int id)
        {
            var entity = FindById(id);
            Remove(entity);
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IQueryable<T> Items()
        {
            return _context.Set<T>();
        }
    }
}
