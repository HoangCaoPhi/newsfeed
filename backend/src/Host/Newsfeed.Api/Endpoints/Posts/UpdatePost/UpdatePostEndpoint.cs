
using Microsoft.AspNetCore.Mvc;
using Newsfeed.Application.Features.Posts.Commands.UpdatePost;

namespace Newsfeed.Api.Endpoints.Posts.UpdatePost;

public class UpdatePostEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("post", async([FromBody] UpdatePostCommand command, IMediator mediator) => 
        {
                var result = await mediator.Send(command);
                return result;
        })
        .WithTags("Post")
        .RequireAuthorization();
    }
}
