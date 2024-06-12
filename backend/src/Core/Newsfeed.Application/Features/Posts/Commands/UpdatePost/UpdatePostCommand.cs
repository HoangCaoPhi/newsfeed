using Newsfeed.Domain.AggregatesModel.PostAggregate;

namespace Newsfeed.Application.Features.Posts.Commands.UpdatePost;

public record UpdatePostCommand(
    int PostId,
    string? Title,
    string Content,
    string? ThumbnailId,
    List<PostAttachment> PostAttachments,
    string DisplayMode,
    List<PostHashTag> PostHashTags,
    List<PostCategoryUpdateRequest> PostCategories) : IRequest<ServiceResponse<int>>;

public class PostCategoryUpdateRequest
{
    public int CategoryId { get; set; }
}

public static class PostCategoryExtension
{
    public static List<PostCategory> ToPostCategoryList(this List<PostCategoryUpdateRequest> categoryRequests)
    {
        return categoryRequests.Select(cr => new PostCategory(cr.CategoryId)).ToList();
    }
}