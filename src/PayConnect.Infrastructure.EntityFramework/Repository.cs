using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PayConnect.Domain.Interfaces;
using PayConnect.Infrastructure.EntityFramework.Context;

namespace PayConnect.Infrastructure.EntityFramework;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _applicationDbContext;
    /// <summary>
    /// Construtor
    /// </summary>
    /// <param name="applicationDbContext"></param>
    public Repository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    /// <inheritdoc />
    public Expression<Func<T, bool>> CreateQuery(Expression<Func<T, bool>> expression)
    {
        return expression;
    }

    /// <inheritdoc />
    public async Task<T?> FirstAsync(Expression<Func<T, bool>> predicate)
    {
        var dado = await _applicationDbContext.Set<T>().FirstOrDefaultAsync(predicate);
        return dado;
    }

    /// <inheritdoc />
    public async Task<T?> FirstAsync(Expression<Func<T?, bool>> predicate, bool asNoTraking)
    {
        if (asNoTraking)
        {
            return await _applicationDbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        return await _applicationDbContext.Set<T>().FirstOrDefaultAsync(predicate);
    }

    /// <inheritdoc />
    public async Task<T?> FirstAsync(bool asNoTraking)
    {
        if (asNoTraking)
        {
            return await _applicationDbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync();
        }

        return await _applicationDbContext.Set<T>().FirstOrDefaultAsync();
    }

    /// <inheritdoc />
    public async Task<T?> FirstAsync()
    {
        return await _applicationDbContext.Set<T>().FirstOrDefaultAsync();
    }

    /// <inheritdoc />
    public async Task<TJ?> FirstAsync<TJ>(Expression<Func<T, bool>> predicate, Expression<Func<T, TJ>> selectPredicate, string[] includes) where TJ : class
    {
        var dbSet = _applicationDbContext.Set<T>();
        var db = includes.Aggregate(dbSet.AsQueryable(), (current, include) => current.Include(include));

        var data = db.Where(predicate).Select(selectPredicate).FirstOrDefaultAsync();

        return await data;
    }

    /// <inheritdoc />
    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        return await _applicationDbContext.Set<T>().Where(predicate).AnyAsync();
    }

    /// <inheritdoc />
    public async Task<bool> AnyAsync()
    {
        return await _applicationDbContext.Set<T>().AnyAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        var data = _applicationDbContext.Set<T>().Where(predicate);
        return await data.ToListAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<TJ>> FindAsync<TJ>(Expression<Func<T, bool>> predicate, Expression<Func<T, TJ>> selectPredicate) where TJ : class
    {
        var data = _applicationDbContext.Set<T>().Where(predicate).Select(selectPredicate);
        return await data.ToListAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<TJ>> FindAsync<TJ>(Expression<Func<T, bool>> predicate, Expression<Func<T, TJ>> selectPredicate, string[] includes) where TJ : class
    {

        var dbSet = _applicationDbContext.Set<T>();
        var db = includes.Aggregate(dbSet.AsQueryable(), (current, include) => current.Include(include));

        var data = db.Where(predicate).Select(selectPredicate);

        return await data.ToListAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<T>> AllAsync(string[] includes)
    {
        var db = _applicationDbContext.Set<T>();

        foreach (var i in includes)
        {
            db.Include(i);
        }
        return await db.ToListAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<TJ>> AllAsync<TJ>(Expression<Func<T, TJ>> selectPredicate) where TJ : class
    {
        return await _applicationDbContext.Set<T>().Select(selectPredicate).ToListAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<T>> AllAsync()
    {
        return await _applicationDbContext.Set<T>().ToListAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<T>> AllAsync(bool asNoTracking)
    {
        if (asNoTracking)
            return await _applicationDbContext.Set<T>().AsNoTracking().ToListAsync();
        return await _applicationDbContext.Set<T>().ToListAsync();
    }

    /// <inheritdoc />
    public async Task AddAsync(T entity)
    {
        await _applicationDbContext.Set<T>().AddAsync(entity);
    }

    /// <inheritdoc />
    public void Delete(T entity)
    {
        _applicationDbContext.Set<T>().Remove(entity);
    }

    /// <inheritdoc />
    public void Update(T entity)
    {
        _applicationDbContext.Entry(entity).State = EntityState.Modified;
        _applicationDbContext.Set<T>().Update(entity);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<TJ>> FindAsPaginatedOrderAsync<TJ>(int currentPage,
        int pageSize,
        Expression<Func<T, object>> orderByPredicate,
        bool orderDesc,
        Expression<Func<T, TJ>> selectPredicate,
        Expression<Func<T, object>>? orderThenByPredicate = null,
        Expression<Func<T, bool>>? query = null,
        string[]? includes = null) where TJ : class
    {

        var dbSet = _applicationDbContext.Set<T>().AsQueryable();

        if (includes is not null)
            dbSet = includes.Aggregate(dbSet.AsQueryable(), (current, include) => current.Include(include));

        var result = query is null ? dbSet : dbSet.Where(query);

        if (orderThenByPredicate is null)
            result = orderDesc ? result.OrderByDescending(orderByPredicate) : result.OrderBy(orderByPredicate);
        else
            result = orderDesc ? result.OrderByDescending(orderByPredicate).ThenByDescending(orderThenByPredicate) :
                                 result.OrderBy(orderByPredicate).ThenBy(orderThenByPredicate);

        return await result.Skip((currentPage - 1) * pageSize)
                           .Take(pageSize)
                           .Select(selectPredicate)
                           .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<int> Count(Expression<Func<T, bool>>? predicate = null)
    {
        var db = _applicationDbContext.Set<T>();
        return predicate is null ? await db.CountAsync() : await db.CountAsync(predicate);
    }
}