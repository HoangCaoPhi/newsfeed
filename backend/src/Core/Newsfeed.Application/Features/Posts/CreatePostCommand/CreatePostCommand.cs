using Newsfeed.Application.Wrappers;
using Newsfeed.Domain.AggregatesModel.PostAggregate;

namespace Newsfeed.Application.Features.Posts.CreatePostCommand;
public record CreatePostCommand(string? Title,
    string Content,
    string PostType,
    string? ThumbnailId,
    List<PostAttachment> PostAttachments,
    string DisplayMode,
    List<PostHashTag> PostHashTags,
    List<PostCategory> PostCategories) : IRequest<ServiceResponse<int>>;

 