using System.Linq.Expressions;

namespace WebApiDemo3_22_10.Repositories.Abstract
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Expression<Func<T, bool>> predicate);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
