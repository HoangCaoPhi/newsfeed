

namespace Newsfeed.Domain.AggregatesModel.PostAggregate;

public enum PostAttachmentType
{
    Image = 1,
    File = 2,
}

public class PostAttachment : ValueObject
{
    public string PostAttachmentName { get; private set; }

    public string? PostAttachmentExtension { get; private set; }

    public PostAttachmentType PostAttachmentType { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return PostAttachmentName;
        yield return PostAttachmentExtension;
        yield return PostAttachmentType;
    }
}
