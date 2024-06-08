using Newsfeed.Domain.AggregatesModel.PostAggregate;

namespace Newsfeed.Infrastructure.Persistence.Repositories;
public class PostRepository(NewsfeedDbContext context) : GenericRepository<Post>(context), IPostRepository
{

}
