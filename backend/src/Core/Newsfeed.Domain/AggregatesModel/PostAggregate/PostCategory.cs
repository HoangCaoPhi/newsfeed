
namespace Newsfeed.Domain.AggregatesModel.PostAggregate;
public class PostCategory 
{
    public int CategoryId { get; private set; } 

    public PostCategory(int categoryId)
    {
        CategoryId = categoryId;
    }
}
