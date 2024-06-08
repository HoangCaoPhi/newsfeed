using Newsfeed.Domain.SeedWork;

namespace Newsfeed.Infrastructure.Persistence.Repositories;
public class GenericRepository<T>(NewsfeedDbContext context) : 
    IRepository<T>, IAggregateRoot 
    where T : class, IAggregateRoot
{ 
    public IUnitOfWork UnitOfWork => context;

    public async Task<T> AddAsync(T entity)
    {
        return (await context.AddAsync(entity))?.Entity;
    }

    public async Task AddListAsync(List<T> entities)
    {
        await context.AddRangeAsync(entities);
    }

    public void DeleteAsync(T entity)
    {
        context.Remove(entity);        
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await context.Set<T>().FindAsync(id);
    }
 
    public void UpdateAsync(T entity)
    {
        context.Entry(entity).State = EntityState.Modified;
    }
}
