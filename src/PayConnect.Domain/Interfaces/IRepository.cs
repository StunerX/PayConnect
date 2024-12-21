using System.Linq.Expressions;

namespace PayConnect.Domain.Interfaces;

/// <summary>
/// Data repository
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T> where T : class
{
    /// <summary>
    /// Create a entity query
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="expression"></param>
    /// <returns></returns>
    Expression<Func<T, bool>> CreateQuery(Expression<Func<T, bool>> expression);
    /// <summary>
    /// Returns the first record from a query without tracking changes
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="asNoTracking"></param>
    /// <returns></returns>
    Task<T?> FirstAsync(Expression<Func<T?, bool>> predicate, bool asNoTracking);
    /// <summary>
    /// Returns the first record from a query
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    Task<T?> FirstAsync(Expression<Func<T, bool>> predicate);
    /// <summary>
    /// Returns the first record
    /// </summary>
    /// <returns></returns>
    Task<T?> FirstAsync();
    /// <summary>
    /// Returns the first record without tracking changes
    /// </summary>
    /// <param name="asNoTracking"></param>
    /// <returns></returns>
    Task<T?> FirstAsync(bool asNoTracking);
    /// <summary>
    /// Returns the first record from a query and converting to DTO
    /// </summary>
    /// <typeparam name="TJ"></typeparam>
    /// <param name="predicate"></param>
    /// <param name="selectPredicate"></param>
    /// <param name="includes"></param>
    /// <returns></returns>
    Task<TJ?> FirstAsync<TJ>(Expression<Func<T, bool>> predicate, Expression<Func<T, TJ>> selectPredicate, string[] includes) where TJ : class;
    /// <summary>
    /// Returns data from a database query
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    /// <summary>
    /// Returns data from a database query and converting to DTO
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="selectPredicate"></param>
    /// <returns></returns>
    Task<IEnumerable<TJ>> FindAsync<TJ>(Expression<Func<T, bool>> predicate, Expression<Func<T, TJ>> selectPredicate) where TJ : class;

    /// <summary>
    /// Returns data from a database query and converting to DTO (you can use includes)
    /// </summary>
    /// <typeparam name="TJ"></typeparam>
    /// <param name="predicate"></param>
    /// <param name="selectPredicate"></param>
    /// <param name="includes"></param>
    /// <returns></returns>
    Task<IEnumerable<TJ>> FindAsync<TJ>(Expression<Func<T, bool>> predicate, Expression<Func<T, TJ>> selectPredicate, string[] includes) where TJ : class;
    /// <summary>
    /// Returns all records of an entity
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<T>> AllAsync();
    /// <summary>
    /// Retorna todos os registro de uma entidade com seleção de campos
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<TJ>> AllAsync<TJ>(Expression<Func<T, TJ>> selectPredicate) where TJ : class;
    /// <summary>
    /// Returns all records of an entity with an option to inject dependent tables
    /// </summary>
    /// <param name="includes"></param>
    /// <returns></returns>
    Task<IEnumerable<T>> AllAsync(string[] includes);
    /// <summary>
    /// Returns all records of an entity without change tracking
    /// </summary>
    /// <param name="asNoTracking"></param>
    /// <returns></returns>
    Task<IEnumerable<T>> AllAsync(bool asNoTracking);
    /// <summary>
    /// Adds a new entity
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task AddAsync(T entity);
    /// <summary>
    /// Removes an entity
    /// </summary>
    /// <param name="entity"></param>
    void Delete(T entity);
    /// <summary>
    /// Updates an entity (set to modified)
    /// </summary>
    /// <param name="entity"></param>
    void Update(T entity);
    /// <summary>
    /// Checks if a query returns records
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    /// <summary>
    /// Checks if an entity has records
    /// </summary>
    /// <returns></returns>
    Task<bool> AnyAsync();

    /// <summary>
    /// Database search with paginated data
    /// </summary>
    /// <typeparam name="TJ"></typeparam>
    /// <param name="currentPage"></param>
    /// <param name="pageSize"></param>
    /// <param name="orderByPredicate"></param>
    /// <param name="orderDesc"></param>
    /// <param name="selectPredicate"></param>
    /// <param name="orderThenByPredicate"></param>
    /// <param name="query"></param>
    /// <param name="includes"></param>
    /// <returns></returns>
    Task<IEnumerable<TJ>> FindAsPaginatedOrderAsync<TJ>(int currentPage,
        int pageSize,
        Expression<Func<T, object>> orderByPredicate,
        bool orderDesc,
        Expression<Func<T, TJ>> selectPredicate,
        Expression<Func<T, object>>? orderThenByPredicate = null,
        Expression<Func<T, bool>>? query = null,
        string[]? includes = null) where TJ : class;

    /// <summary>
    /// Count rows in query
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    Task<int> Count(Expression<Func<T, bool>>? predicate = null);
}