using MapsterMapper;
using Newsfeed.Domain.AggregatesModel.PostAggregate;

namespace Newsfeed.Application.Features.Posts.Commands.CreatePostCommand;
public class CreatePostCommandHandler(IPostRepository postRepo, IMapper mapper) : IRequestHandler<CreatePostCommand, ServiceResponse<int>>
{
    public async Task<ServiceResponse<int>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var postCategories = request.PostCategories.ToPostCategoryList();
        var post = Post.CreatePost(request.Title, 
                                   request.PostType, 
                                   request.ThumbnailId, 
                                   request.DisplayMode, 
                                   request.Content,
                                   request.PostHashTags,
                                   request.PostAttachments,
                                   postCategories);

        postRepo.AddAsync(post);
        await postRepo.UnitOfWork.SaveChangesAsync(cancellationToken);

        return new ServiceResponse<int>(post.Id);
    }
}
