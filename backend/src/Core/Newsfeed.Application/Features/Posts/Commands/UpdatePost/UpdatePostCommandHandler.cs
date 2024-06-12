
using Newsfeed.Application.Exceptions;
using Newsfeed.Domain.AggregatesModel.PostAggregate;

namespace Newsfeed.Application.Features.Posts.Commands.UpdatePost;
public class UpdatePostCommandHandler(IPostRepository postRepository) : IRequestHandler<UpdatePostCommand, ServiceResponse<int>>
{
    public async Task<ServiceResponse<int>> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var post = await postRepository.GetByIdAsync(request.PostId) ?? 
                   throw new ApiException("Post not exist");

        var postCategories = request.PostCategories.ToPostCategoryList();
        post.UpdatePost(request.Title,
                        request.ThumbnailId,
                        request.DisplayMode,
                        request.Content,
                        request.PostHashTags,
                        request.PostAttachments,
                        postCategories);

        await postRepository.UnitOfWork.SaveChangesAsync();

        return new ServiceResponse<int>(post.Id);
    }
}
