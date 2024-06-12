using Newsfeed.Domain.AggregatesModel.PostAggregate;

namespace Newsfeed.Application.Features.Posts.Commands.CreatePostCommand;

public record CreatePostCommand(string? Title,
    string Content,
    string PostType,
    string? ThumbnailId,
    List<PostAttachment> PostAttachments,
    string DisplayMode,
    List<PostHashTag> PostHashTags,
    List<PostCategoryCreateRequest> PostCategories) : IRequest<ServiceResponse<int>>;

public class PostCategoryCreateRequest
{
    public int CategoryId { get; set; }
}

public static class PostCategoryExtension
{
    public static List<PostCategory> ToPostCategoryList(this List<PostCategoryCreateRequest> categoryRequests)
    {
        return categoryRequests.Select(cr => new PostCategory(cr.CategoryId)).ToList();
    }
}
