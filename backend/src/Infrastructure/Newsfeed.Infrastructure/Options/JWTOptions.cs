namespace Newsfeed.Infrastructure.Options;
public class JWTOptions
{
    public static string GetSectionName() => "JWTSettings";

    public required string SecretKey { get; set; } 

    public required string Issuer { get; set; }

    public required string Audience { get; set; }

    public double DurationInMinutes { get; set; }

    public string? PrivatekeyPath { get; set; }
}