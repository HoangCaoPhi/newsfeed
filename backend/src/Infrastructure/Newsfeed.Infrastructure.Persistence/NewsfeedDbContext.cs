using Microsoft.EntityFrameworkCore;

namespace Newsfeed.Infrastructure.Persistence;
public class NewsfeedDbContext(DbContextOptions<NewsfeedDbContext> options) : DbContext(options)
{
}
