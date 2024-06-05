
namespace Newsfeed.Domain.AggregatesModel.PostAggregate;
public class Author(string AuthorId, string AuthorName) : ValueObject
{
    public string AuthorId { get; private set; } = AuthorId;

    public string AuthorName { get; private set; } = AuthorName;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return AuthorId;
        yield return AuthorName;
    }
}
