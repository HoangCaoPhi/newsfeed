using Newsfeed.Domain.AggregatesModel.PostAggregate;
using Newsfeed.Domain.AggregatesModel.PostAggregate.Enums;

namespace Newsfeed.Application.Features.Posts.Queries.GetOne;

public class GetOneCategoryResponse
{
    public int CategoryId { get; init; }
    public string CategoryName { get; init; }
}


public record GetOnePostResponse
{
    public string? Title { get; init; }

    public string Content { get; init; }

    public PostType PostType { get; init; }

    public string? ThumbnailId { get; init; }

    public DisplayMode DisplayMode { get; init; }

    public Author Author { get; init; }

    public IReadOnlyCollection<PostAttachment> PostAttachments { get; init; }

    public IReadOnlyCollection<PostHashTag> PostHashTags { get; init; }

    public IReadOnlyCollection<GetOneCategoryResponse> Categories { get; init; }
}
