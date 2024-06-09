using Microsoft.AspNetCore.Http;
using Newsfeed.Application.Interfaces;
using Newsfeed.Infrastructure.Identity.Extensions;

namespace Newsfeed.Infrastructure.Identity.Implements;
internal class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public string UserId =>
       httpContextAccessor
           .HttpContext?
           .User
           .GetUserId() ??
       throw new ApplicationException("User context is unavailable");

    public bool IsAuthenticated =>
        httpContextAccessor
            .HttpContext?
            .User
            .Identity?
            .IsAuthenticated ??
        throw new ApplicationException("User context is unavailable");

    public string FullName => httpContextAccessor
           .HttpContext?
           .User
           .GetFullName() ??
       throw new ApplicationException("Fullname context is unavailable");

    public string Email
    {
        get
        {
            return httpContextAccessor
           .HttpContext?
           .User
           .GetEmail() ?? throw new ApplicationException("Email context is unavailable");
        }
    }
}
