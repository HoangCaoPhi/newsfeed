
namespace Newsfeed.Domain.AggregatesModel.PostAggregate;
public class HashTag(string name) : ValueObject
{
    public string Name { get; init; } = name;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return new object[] { Name };
    }
}
