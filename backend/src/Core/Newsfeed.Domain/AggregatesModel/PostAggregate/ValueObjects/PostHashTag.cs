
namespace Newsfeed.Domain.AggregatesModel.PostAggregate;
public class PostHashTag(string name) : ValueObject
{
    public string Name { get; init; } = name;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return new object[] { Name };
    }
}
