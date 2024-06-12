using Microsoft.EntityFrameworkCore;
using Newsfeed.Domain.AggregatesModel.PostAggregate;

namespace Newsfeed.Domain.SeedWork;

/// <summary>
/// Implement 
/// </summary>
public interface INewsfeedReadDbContext
{
    public DbSet<Post> Posts { get; }
}
