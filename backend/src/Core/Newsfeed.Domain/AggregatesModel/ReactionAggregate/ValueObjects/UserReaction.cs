
namespace Newsfeed.Domain.AggregatesModel.ReactionAggregate.ValueObjects;
public class UserReaction : ValueObject
{
    public string Value { get; init; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
