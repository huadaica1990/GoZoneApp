using GoZoneApp.Infrastructure.Interfaces;
using GoZoneApp.Infrastructure.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GoZoneApp.Data.EF
{
    public class EFRepository<T, K> : IRepository<T, K>, IDisposable where T : DomainEntity<K>
    {
        private readonly AppDbContext _context;
        public EFRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            try
            {
                _context.Add(entity);
            }
            catch (Exception e)
            {
                var msg = e;
            }
        }

        public void Dispose()
        {
            try
            {
                if(_context != null ) _context.Dispose();
            }
            catch (Exception e)
            {
                var msg = e;
            }
        }

        public IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _context.Set<T>();
            if(includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items;
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _context.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items.Where(predicate);
        }

        public IQueryable<T> FindAll(int page, int pagesize, ref int totalitem)
        {
            IQueryable<T> items = _context.Set<T>();
            totalitem = items.Count();
            items = items.OrderByDescending(m => m.Id).Skip((page - 1) * pagesize).Take(pagesize);
            return items;
        }

        public IQueryable<T> FindAll(int page, int pagesize, ref int totalitem, Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> items = _context.Set<T>();
            items = items.Where(predicate);
            totalitem = items.Count();
            items = items.OrderByDescending(m => m.Id).Skip((page - 1) * pagesize).Take(pagesize);
            return items;
        }

        public T FindById(K id, params Expression<Func<T, object>>[] includeProperties)
        {
            return FindAll(includeProperties).SingleOrDefault(x => x.Id.Equals(id));
        }

        public T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return FindAll(includeProperties).SingleOrDefault(predicate);
        }

        public void Remove(T entity)
        {
            try
            {
                if (entity is INoDelete temp && temp.NoDeleted) return;
                if (entity is IHasSoftDelete temp1) temp1.IsDeleted = true;
                else _context.Set<T>().Remove(entity);
            }
            catch (Exception e)
            {
                var msg = e;
            }
        }

        public void Remove(K id)
        {
            Remove(FindById(id));
        }

        public void RemoveMultiple(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
