using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ECommerceProductCatalog.Application.Interfaces;
using ECommerceProductCatalog.Infrastructure.Persistence;
using System.Reflection;

namespace ECommerceProductCatalog.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public async Task<IEnumerable<T>> Get(int page, int pageSize, string? orderBy = null, bool desc = false)
    {
        IQueryable<T> query = _dbSet;

        if (!string.IsNullOrEmpty(orderBy))
        {
            var property = typeof(T).GetProperty(orderBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (property != null)
            {
                query = desc
                    ? query.OrderByDescending(e => EF.Property<object>(e, property.Name))
                    : query.OrderBy(e => EF.Property<object>(e, property.Name));
            }
        }

        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
    public async Task<IEnumerable<T>> Get(
    int page,
    int pageSize,
    string? orderBy,
    bool desc,
    Expression<Func<T, bool>>? filter = null)
    {
        IQueryable<T> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (!string.IsNullOrEmpty(orderBy))
        {
            var property = typeof(T).GetProperty(
                orderBy,
                BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance
            );

            if (property != null)
            {
                query = desc
                    ? query.OrderByDescending(e => EF.Property<object>(e, property.Name))
                    : query.OrderBy(e => EF.Property<object>(e, property.Name));
            }
        }

        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
    public async Task<int> Count()
    {
        return await _dbSet.CountAsync();
    }
    public async Task<int> Count(Expression<Func<T, bool>>? filter = null)
    {
        if (filter != null)
        {
            return await _dbSet.CountAsync(filter);
        }
        return await _dbSet.CountAsync();
    }
}