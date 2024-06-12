
using Newsfeed.Domain.AggregatesModel.CategoryAggregate;

namespace Newsfeed.Domain.AggregatesModel.PostAggregate;
public class PostCategory 
{
    public int CategoryId { get; private set; } 
    public Post Post { get; private set; } 
    public Category Category { get; private set; } 

    public PostCategory(int categoryId)
    {
        CategoryId = categoryId;
    }
}
