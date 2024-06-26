

using System.Linq.Expressions;

namespace Tournaments.Core.Interfaces;

public interface IRepository<T> where T : IBaseEntity
{
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<T?> GetAsync(int id);
    public Task<T?> GetAsyncWithChildren(int id);
    public Task<IEnumerable<T>> GetAsyncByParams(IQueryParameters queryParameters);
    public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    public Task<T?> AddAsync(T entity);
    public Task<T?> UpdateAsync(T entity);
    public Task<T?> RemoveAsync(int entityId);
}