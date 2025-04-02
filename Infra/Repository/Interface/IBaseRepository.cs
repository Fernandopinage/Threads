using Domain.Entity;
using System.Linq.Expressions;

namespace Infra.Repository.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
        Task<T> GetByAsync(Expression<Func<T, bool>> predicate);
    }

}
