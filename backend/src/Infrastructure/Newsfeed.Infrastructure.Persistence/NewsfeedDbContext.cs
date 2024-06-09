using Newsfeed.Application.Interfaces;
using Newsfeed.Domain.AggregatesModel.CategoryAggregate;
using Newsfeed.Domain.AggregatesModel.PostAggregate;
using Newsfeed.Domain.SeedWork;

namespace Newsfeed.Infrastructure.Persistence;
public class NewsfeedDbContext(DbContextOptions<NewsfeedDbContext> options,
    IUserContext userContext) : DbContext(options), IUnitOfWork
{
    public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(true);
    }

    public DbSet<Post> Posts { get; set; }

    public DbSet<Category> Categorys { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(IAssemblyMarker).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<IRecordHistory>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created = DateTime.UtcNow;
                    entry.Entity.CreatedBy = userContext.FullName;
                    entry.Entity.EditVersion = Guid.NewGuid();
                    entry.Entity.ModifiedBy = userContext.FullName; 
                    entry.Entity.Modified = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.Modified = DateTime.UtcNow;
                    entry.Entity.ModifiedBy = userContext.FullName;
                    entry.Entity.EditVersion = Guid.NewGuid();
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
