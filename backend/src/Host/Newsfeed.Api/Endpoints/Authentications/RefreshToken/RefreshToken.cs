
using Microsoft.AspNetCore.Mvc;
using Newsfeed.Application.Dtos.Users;
using Newsfeed.Application.Services;

namespace Newsfeed.Api.Endpoints.Authentications.RefreshToken;

public class RefreshToken : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/refresh-token", async ([FromBody] RefreshTokenRequest request, IAuthenticationService authenticationService) =>
        {
            return await authenticationService.RefreshToken(request);
        }); 
    }
}
