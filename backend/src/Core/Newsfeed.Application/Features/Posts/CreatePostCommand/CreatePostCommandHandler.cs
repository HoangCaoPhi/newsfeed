using Newsfeed.Application.Wrappers;
using Newsfeed.Domain.AggregatesModel.PostAggregate;

namespace Newsfeed.Application.Features.Posts.CreatePostCommand;
public class CreatePostCommandHandler(IPostRepository postRepo) : IRequestHandler<CreatePostCommand, ServiceResponse<int>>
{
    public async Task<ServiceResponse<int>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var post = Post.CreatePost(request.Title, request.PostType, request.ThumbnailId, request.DisplayMode, request.Content);

        post.AddPostHashTags(request.PostHashTags);
        post.AddPostAttachments(request.PostAttachments);
        post.AddPostCategories(request.PostCategories);

        postRepo.AddAsync(post);
        await postRepo.UnitOfWork.SaveChangesAsync(cancellationToken);

        return new ServiceResponse<int>(post.Id);
    }
}
