namespace Newsfeed.Domain.AggregatesModel.CategoryAggregate;
public class Category : IAggregateRoot
{
    public string CategoryName { get; private set; }
}
