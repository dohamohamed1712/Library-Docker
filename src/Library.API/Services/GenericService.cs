using System.Linq.Expressions;
using AutoMapper;
using Library.API.Repositories;
using Library.API.Results;

namespace Library.API.Services;

public class GenericService<TEntity, TResponse, TCreate, TUpdate> : IGenericService<TEntity, TResponse, TCreate, TUpdate>
    where TEntity : class
{
    protected readonly IGenericRepository<TEntity> Repository;
    protected readonly IMapper Mapper;

    public GenericService(IGenericRepository<TEntity> repository, IMapper mapper)
    {
        Repository = repository;
        Mapper = mapper;
    }

    public virtual async Task<GenericResult<IEnumerable<TResponse>>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
    {
        var entities = await Repository.GetAllAsync(includes);
        var data = Mapper.Map<IEnumerable<TResponse>>(entities);
        return GenericResult<IEnumerable<TResponse>>.Ok(data, "Retrieved successfully");
    }

    public virtual async Task<GenericResult<TResponse>> GetByIdAsync(params object[] key)
    {
        var entity = await Repository.GetByIdAsync(key);
        if (entity is null)
        {
            return GenericResult<TResponse>.Fail("Not found");
        }
        return GenericResult<TResponse>.Ok(Mapper.Map<TResponse>(entity), "Retrieved successfully");
    }

    public virtual async Task<GenericResult<TResponse>> CreateAsync(TCreate dto)
    {
        var entity = Mapper.Map<TEntity>(dto);
        await Repository.AddAsync(entity);
        await Repository.SaveChangesAsync();
        return GenericResult<TResponse>.Ok(Mapper.Map<TResponse>(entity), "Created successfully");
    }

    public virtual async Task<Result> UpdateAsync(object[] key, TUpdate dto)
    {
        var entity = await Repository.GetByIdAsync(key);
        if (entity is null)
        {
            return Result.Fail("Not found");
        }

        Mapper.Map(dto, entity);
        Repository.Update(entity);
        await Repository.SaveChangesAsync();
        return Result.Ok("Updated successfully");
    }

    public virtual async Task<Result> DeleteAsync(params object[] key)
    {
        var entity = await Repository.GetByIdAsync(key);
        if (entity is null)
        {
            return Result.Fail("Not found");
        }

        Repository.Remove(entity);
        await Repository.SaveChangesAsync();
        return Result.Ok("Deleted successfully");
    }
}
