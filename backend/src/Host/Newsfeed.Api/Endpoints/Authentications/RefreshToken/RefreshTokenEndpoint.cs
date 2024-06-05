
using Microsoft.AspNetCore.Mvc;
using Newsfeed.Application.Dtos.Users;
using Newsfeed.Application.Services;

namespace Newsfeed.Api.Endpoints.Authentications.RefreshToken;

public class RefreshTokenEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/authentication/refresh-token", async ([FromBody] RefreshTokenRequest request, IAuthenticationService authenticationService) =>
        {
            return await authenticationService.RefreshToken(request);
        })
        .WithTags(EndpointSchema.Authentication)
        .MapToApiVersion(1); 
    }
}
