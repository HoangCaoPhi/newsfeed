
using Newsfeed.Application.Features.Posts.Queries.GetOne;

namespace Newsfeed.Api.Endpoints.Posts.GetOne;

public class GetOneEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("post/{postId}", async (int postId, IMediator mediator) =>
        {
            var post = await mediator.Send(new GetOnePostQuery(postId));
            return post;
        })
        .WithTags("Post")
        .RequireAuthorization();        
    }
}
