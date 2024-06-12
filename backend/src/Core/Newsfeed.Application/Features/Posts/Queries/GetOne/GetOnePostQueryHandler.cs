
using Microsoft.EntityFrameworkCore;
using Newsfeed.Domain.SeedWork;

namespace Newsfeed.Application.Features.Posts.Queries.GetOne;
public class GetOnePostQueryHandler(INewsfeedReadDbContext context) : IRequestHandler<GetOnePostQuery, ServiceResponse<GetOnePostResponse>>
{
    public async Task<ServiceResponse<GetOnePostResponse>> Handle(GetOnePostQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Posts
                     .Where(x => x.Id == request.PostId)
                     .Include(x => x.PostCategories)
                        .ThenInclude(x => x.Category)
                     .Select(post => new GetOnePostResponse()
                     {
                         Title = post.Title,
                         Content = post.Content,
                         ThumbnailId = post.ThumbnailId,
                         PostType = post.PostType,
                         Author = post.Author,
                         DisplayMode = post.DisplayMode,
                         PostAttachments = post.PostAttachments,
                         Categories =  post.PostCategories.Select(x => 
                                                         new GetOneCategoryResponse()
                                                         {
                                                             CategoryId = x.Category.Id,
                                                             CategoryName = x.Category.CategoryName
                                                         }).ToList(),
                         PostHashTags = post.PostHashTags
                     })
                     .AsNoTracking()
                     .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        return new ServiceResponse<GetOnePostResponse>(result);
    }
}
