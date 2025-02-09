using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface ICrudRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
    }
}
