using System.Linq.Expressions;
using Library.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly LibraryDbContext Context;
    protected readonly DbSet<T> Set;

    public GenericRepository(LibraryDbContext context)
    {
        Context = context;
        Set = context.Set<T>();
    }

    public IQueryable<T> Query() => Set.AsQueryable();

    public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = Set.AsNoTracking();
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        return await query.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(params object[] key) => await Set.FindAsync(key);

    public async Task<T> AddAsync(T entity) => (await Set.AddAsync(entity)).Entity;

    public void Update(T entity) => Set.Update(entity);

    public void Remove(T entity) => Set.Remove(entity);

    public Task<int> SaveChangesAsync() => Context.SaveChangesAsync();
}
