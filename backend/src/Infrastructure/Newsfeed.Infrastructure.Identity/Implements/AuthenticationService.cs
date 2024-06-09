using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newsfeed.Application.Dtos.Users;
using Newsfeed.Application.Exceptions;
using Newsfeed.Application.Services;
using Newsfeed.Application.Wrappers;
using Newsfeed.Infrastructure.Identity.Enums;
using Newsfeed.Infrastructure.Identity.Models;
using Newsfeed.Infrastructure.Options;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Sockets;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Newsfeed.Infrastructure.Identity.Implements;

public class AuthenticationService(UserManager<ApplicationUser> userManager,
                                   SignInManager<ApplicationUser> signInManager,
                                   RoleManager<IdentityRole> roleManager,
                                   IOptions<JWTOptions> jwtOptions) : IAuthenticationService
{
    private readonly JWTOptions _jwtOptions = jwtOptions.Value;

    #region Resgier
    public async Task<ServiceResponse<IdentityResult>> RegisterAsync(RegisterRequest request, string origin)
    {
        var userWithSameUserName = await userManager.FindByNameAsync(request.UserName);
        if (userWithSameUserName is not null) throw new ApiException($"Username '{request.UserName}' is already taken.");

        var userWithSameEmail = await userManager.FindByEmailAsync(request.Email);
        if (userWithSameEmail is not null) throw new ApiException($"Email {request.Email} is already registered.");

        var user = new ApplicationUser()
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.UserName
        };

        var result = await userManager.CreateAsync(user, request.Password);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, RoleDefault.Employee.ToString());
            return new ServiceResponse<IdentityResult>(result);
        }
        else
        {
            throw new ApiException($"Register failed with error: {result.Errors}");
        }
    }
    #endregion

    #region Login
    public async Task<ServiceResponse<LoginReponse>> LoginAsync(LoginRequest request)
    {
        var user = await userManager.FindByEmailAsync(request.Email) ?? throw new ApiException($"No Accounts Registered with {request.Email}.");

        var signInResult = await signInManager.PasswordSignInAsync(user, request.Password, isPersistent: false, lockoutOnFailure: false);
        if (!signInResult.Succeeded) throw new ApiException($"Invalid Credentials for '{request.Email}'.");

        string ipAddress = GetIpAddress();
        var token = await GenerateToken(user, ipAddress);
        var refreshToken = await GenerateRefreshToken(ipAddress, user);

        var roles = await userManager.GetRolesAsync(user);

        var result = new LoginReponse()
        {
            UserName = user.UserName,
            Email = user.Email,
            UserId = user.Id,
            Roles = roles.ToList(),
            Token = token,
            RefreshToken = refreshToken.Token
        };

        return new ServiceResponse<LoginReponse>(result);
    }
    #endregion

    #region Generation Token
    private async Task<string> GetPermissionByRole(string roleName)
    {
        var role = await roleManager.FindByNameAsync(roleName);
        var roleClaims = await roleManager.GetClaimsAsync(role);

        List<ResourcePermission> resourcePermissions = [];
        foreach (var claim in roleClaims)
        {
            resourcePermissions.Add(new ResourcePermission()
            {
                Resource = claim.Type,
                Action = claim.Value.Split("#")
            });
        }

        var rolePermissions = new
        {
            Role = roleName,
            Permissions = resourcePermissions
        };

        return JsonConvert.SerializeObject(rolePermissions);
    }

    public static string GetIpAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        return string.Empty;
    }

    private async Task<string> GenerateToken(ApplicationUser user, string ipAddress)
    {
        var userClaims = await userManager.GetClaimsAsync(user);
        var roles = await userManager.GetRolesAsync(user);

        var roleClaims = new List<Claim>();

        foreach (var role in roles)
        {
            roleClaims.Add(new Claim("roles", await GetPermissionByRole(role.ToString())));
        }

        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("fullname", user.FirstName + " " + user.LastName),
                new Claim("uid", user.Id),
                new Claim("ip", ipAddress)
        }
        .Union(userClaims)
        .Union(roleClaims);

        return GenerateJwtSecurityTokenString(claims);
    }

    public string GenerateJwtSecurityTokenString(IEnumerable<Claim> claims)
    {
        SigningCredentials signingCredentials;
        if (File.Exists(_jwtOptions.PrivatekeyPath))
        {
            RsaSecurityKey rsaSecurityKey = GenerateRsaKey();
            signingCredentials = new SigningCredentials(rsaSecurityKey, SecurityAlgorithms.RsaSha256);
        }
        else
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
            signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        }

        var jwtSecurityToken = GenerateJwtSecurityToken(claims, signingCredentials);
        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }

    private RsaSecurityKey GenerateRsaKey()
    {
        var rsaKey = RSA.Create();
        string xmlKey = File.ReadAllText(_jwtOptions.PrivatekeyPath);
        rsaKey.FromXmlString(xmlKey);
        var rsaSecurityKey = new RsaSecurityKey(rsaKey);
        return rsaSecurityKey;
    }

    private JwtSecurityToken GenerateJwtSecurityToken(IEnumerable<Claim> claims, SigningCredentials signingCredentials)
    {
        return new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtOptions.DurationInMinutes),
            signingCredentials: signingCredentials
        );
    }
    #endregion

    #region Generation Refresh Token
    private async Task<RefreshToken> GenerateRefreshToken(string ipAddress, ApplicationUser user)
    {
        var refreshToken = new RefreshToken
        {
            Token = GenerateRefreshToken(),
            Expires = DateTime.UtcNow.AddDays(7),
            Created = DateTime.UtcNow,
            CreatedByIp = ipAddress
        };
        user.RefreshTokens = [refreshToken];
        await userManager.UpdateAsync(user);
        return refreshToken;
    }

    private static string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        string refreshToken = "";

        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            refreshToken = Convert.ToBase64String(randomNumber);
        }

        return refreshToken;
    }

    public ClaimsPrincipal GetPricipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
            ValidateLifetime = false,
            ValidIssuer = _jwtOptions.Issuer,
            ValidAudience = _jwtOptions.Audience
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");

        return principal;
    }

    public async Task<RefreshTokenResponse> RefreshToken(RefreshTokenRequest request)
    {
        var principal = GetPricipalFromExpiredToken(request.Token) ?? throw new SecurityTokenException("Invalid token");
        var ipAddress = GetIpAddress();

        var uid = principal.FindFirst("uid")?.Value;
        var user = await userManager
            .Users.Include(x => x.RefreshTokens
            .Where(t =>
                t.Token == request.RefreshToken
                && t.Expires > DateTime.UtcNow
                && t.CreatedByIp == ipAddress
            )).FirstAsync(x => x.Id == uid);

        if (user.RefreshTokens.Count > 0)
        {
            var jwtSecurityToken = await GenerateToken(user, ipAddress);
            var newRefreshToken = await GenerateRefreshToken(ipAddress, user);
            return new RefreshTokenResponse()
            {
                Token = jwtSecurityToken,
                RefreshToken = newRefreshToken.Token
            };
        }

        throw new SecurityTokenException("Invalid token");
    }
    #endregion
}
