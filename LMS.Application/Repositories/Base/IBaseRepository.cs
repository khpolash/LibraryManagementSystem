using System.Linq.Expressions;

namespace LMS.Application.Repositories.Base;

public interface IBaseRepository<T> where T : class
{
    IQueryable<T> GetAll();

    Task<List<T>> GetAllAsync();

    IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);

    Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);

    T FirstOrDefault(long? id);

    Task<T> FirstOrDefaultAsync(long? id);

    T FirstOrDefault(long? id, params Expression<Func<T, object>>[] includeProperties);

    Task<T> FirstOrDefaultAsync(long? id, params Expression<Func<T, object>>[] includeProperties);

    #region CURD Operation
    Task InsertAsync(T entity);
    Task UpdateAsync(T entity);
    Task UpdateAsync(object id, T entity);
    Task<T> DeleteAsync(object id);

    #endregion

}
