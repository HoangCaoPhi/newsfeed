
namespace Newsfeed.Domain.AggregatesModel.PostAggregate.ValueObjects;
public class PostRection : ValueObject
{
    public int Value { get; init; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
