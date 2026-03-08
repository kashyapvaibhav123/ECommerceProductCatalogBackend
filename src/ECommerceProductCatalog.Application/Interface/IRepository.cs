using System.Linq.Expressions;

namespace ECommerceProductCatalog.Application.Interfaces;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();

    Task<T?> GetByIdAsync(int id);

    Task AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);
    Task<int> Count();
    //overload function for the Count to Support the Filter
    Task<int> Count(Expression<Func<T, bool>> filter);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> Get(int page, int pageSize, string? orderBy = null, bool desc = false);
    //overload function for the Get to Support the Filter
    Task<IEnumerable<T>> Get(int page, int pageSize, string? orderBy, bool desc, Expression<Func<T, bool>> filter);
}