using Microsoft.AspNetCore.Identity;
using Newsfeed.Application.Dtos.Users;
using Newsfeed.Application.Wrappers;

namespace Newsfeed.Application.Services;
public interface IAuthenticationService
{
    Task<ServiceResponse<IdentityResult>> RegisterAsync(RegisterRequest request, string origin);

    Task<ServiceResponse<LoginReponse>> LoginAsync(LoginRequest request);

    Task<RefreshTokenResponse> RefreshToken(RefreshTokenRequest request);
}
