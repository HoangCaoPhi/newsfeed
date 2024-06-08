namespace Newsfeed.Domain.SeedWork;
public interface IRepository<T> where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }

    Task<T> GetByIdAsync(int id);

    Task<T> AddAsync(T entity);

    Task AddListAsync(List<T> entities);

    void UpdateAsync(T entity);

    void DeleteAsync(T entity);

    Task<IReadOnlyList<T>> GetAllAsync();
}
