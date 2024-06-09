using System.Security.Claims;

namespace Newsfeed.Infrastructure.Identity.Extensions;
internal static class ClaimsPrincipalExtensions
{
    public static string GetUserId(this ClaimsPrincipal? principal)
    {
        return principal?.FindFirstValue("uid"); 
    }

    public static string GetFullName(this ClaimsPrincipal? principal)
    {
        return principal?.FindFirstValue("fullname"); 
    }

    public static string GetEmail(this ClaimsPrincipal? principal)
    {
        return principal?.FindFirstValue("email"); 
    }
}