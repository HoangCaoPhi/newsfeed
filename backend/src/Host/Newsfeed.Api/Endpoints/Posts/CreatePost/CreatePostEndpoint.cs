using Microsoft.AspNetCore.Mvc;
using Newsfeed.Application.Features.Posts.CreatePostCommand;

namespace Newsfeed.Api.Endpoints.Posts.CreatePost;

public class CreatePostEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("post", async ([FromBody] CreatePostCommand command, 
            IMediator mediator) =>
        {
            var result = await mediator.Send(command);
            return result;
        })
        .MapToApiVersion(1)
        .WithTags("Post");
    }
}
