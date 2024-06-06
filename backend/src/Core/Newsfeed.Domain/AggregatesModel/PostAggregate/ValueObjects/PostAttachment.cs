

namespace Newsfeed.Domain.AggregatesModel.PostAggregate;

public enum PostAttachmentType
{
    Image = 1,
    File = 2,
}

public class PostAttachment : ValueObject
{
    public string PostAttachmentName { get; init; }

    public string? PostAttachmentExtension { get; init; }

    public PostAttachmentType PostAttachmentType { get; init; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return PostAttachmentName;
        yield return PostAttachmentExtension;
        yield return PostAttachmentType;
    }
}
