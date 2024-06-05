using System.Text.Json.Serialization;

namespace Newsfeed.Application.Dtos.Users;

public class LoginReponse
{
    public string UserId { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public List<string> Roles { get; set; }

    public bool IsVerified { get; set; }

    public string Token { get; set; }

    [JsonIgnore]
    public string RefreshToken { get; set; }
}