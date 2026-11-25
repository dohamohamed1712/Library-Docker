using System.Linq.Expressions;
using Library.API.Results;

namespace Library.API.Services;

public interface IGenericService<TEntity, TResponse, TCreate, TUpdate> where TEntity : class
{
    Task<GenericResult<IEnumerable<TResponse>>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
    Task<GenericResult<TResponse>> GetByIdAsync(params object[] key);
    Task<GenericResult<TResponse>> CreateAsync(TCreate dto);
    Task<Result> UpdateAsync(object[] key, TUpdate dto);
    Task<Result> DeleteAsync(params object[] key);
}
