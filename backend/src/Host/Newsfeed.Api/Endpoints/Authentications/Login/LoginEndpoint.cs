
using Microsoft.AspNetCore.Mvc;
using Newsfeed.Application.Dtos.Users;
using Newsfeed.Application.Services;

namespace Newsfeed.Api.Endpoints.Users.Login;

public class LoginEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/authentication/login", async ([FromBody] LoginRequest request, IAuthenticationService authenticationService) =>
        {
            return await authenticationService.LoginAsync(request);
        })
        .WithTags(EndpointSchema.Authentication)
        .MapToApiVersion(1);
    }
}
