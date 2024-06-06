namespace Newsfeed.Domain.AggregatesModel.CategoryAggregate;
public class Category : BaseEntity, IAggregateRoot
{
    public string CategoryName { get; private set; }
}
