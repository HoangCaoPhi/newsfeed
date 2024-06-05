using System.ComponentModel.DataAnnotations;

namespace Newsfeed.Application.Dtos.Users;
public class LoginRequest
{
    [EmailAddress]
    public required string Email { get; set; }
    public required string Password { get; set; }
}