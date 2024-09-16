using System.Linq.Expressions;

namespace WebApiDemo3_22_10.Services.Abstract
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Expression<Func<T, bool>> predicate);
        Task Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);
    }
}
