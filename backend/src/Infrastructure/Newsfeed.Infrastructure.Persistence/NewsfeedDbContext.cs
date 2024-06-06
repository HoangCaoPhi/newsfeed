using Microsoft.EntityFrameworkCore;
using Newsfeed.Domain.AggregatesModel.CategoryAggregate;
using Newsfeed.Domain.AggregatesModel.PostAggregate;
using Newsfeed.Domain.SeedWork;

namespace Newsfeed.Infrastructure.Persistence;
public class NewsfeedDbContext(DbContextOptions<NewsfeedDbContext> options) : DbContext(options), IUnitOfWork
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
}
