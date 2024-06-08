
namespace Newsfeed.Domain.AggregatesModel.PostAggregate;
public class Author(string AuthorId, string AuthorName) : ValueObject
{
    public string AuthorId { get; init; } = AuthorId;

    public string AuthorName { get; init; } = AuthorName;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return AuthorId;
        yield return AuthorName;
    }    

    public static Author CreateAuthor(string AuthorId, string AuthorName)
    {
        return new Author(AuthorId, AuthorName);
    }
}
