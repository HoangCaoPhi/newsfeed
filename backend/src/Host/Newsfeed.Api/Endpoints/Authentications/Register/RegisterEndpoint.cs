using Microsoft.AspNetCore.Mvc;
using Newsfeed.Application.Dtos.Users;
using Newsfeed.Application.Services;

namespace Newsfeed.Api.Endpoints.Users.Register;

public class RegisterEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/authentication/register", async ([FromBody] RegisterRequest request,
                                                  IAuthenticationService authenticationService,
                                                  HttpContext context) =>
        {
            var origin = context.Request.Headers.Origin;
            var result = await authenticationService.RegisterAsync(request, origin);
            return result;
        })
        .WithTags(EndpointSchema.Authentication)
        .MapToApiVersion(1);
    }
}
