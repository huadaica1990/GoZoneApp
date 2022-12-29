using System.Linq.Expressions;

namespace GoZoneApp.Infrastructure.Interfaces
{
    public interface IRepository<T, K> where T : class
    {
        T FindById(K id, params Expression<Func<T, object>>[] includeProperties);
        T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> FindAll(int page, int pagesize, ref int totalitem);
        IQueryable<T> FindAll(int page, int pagesize, ref int totalitem, Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Remove(K id);
        void RemoveMultiple(List<T> entities);
    }
}
