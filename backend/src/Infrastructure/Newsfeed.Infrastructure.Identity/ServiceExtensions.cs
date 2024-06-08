using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newsfeed.Application.Services;
using Newsfeed.Application.Wrappers;
using Newsfeed.Infrastructure.Identity.Implements;
using Newsfeed.Infrastructure.Identity.Models;
using Newsfeed.Infrastructure.Options;
using Newsfeed.Infrastructure.Persistence.Options;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace Newsfeed.Infrastructure.Identity;

public static class ServiceExtensions
{
    public static void AddInfrastructureIdentityLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JWTOptions>(configuration.GetSection(JWTOptions.GetSectionName()));

        services.AddDbContext(configuration);

        services.AddIdentityConfig();
        services.AddJwtAuthentication(configuration);

        services.AddServices();
    }

    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IdentityDbAppContext>(options =>
        {
            var databaseMySqlOptions = configuration.GetSection(MySQLOptions.GetSectionName()).Get<MySQLOptions>();
            options.UseMySQL(databaseMySqlOptions.ConnectionString, dbOptions =>
            {
                dbOptions.EnableRetryOnFailure(databaseMySqlOptions.EnableRetryOnFailure);
            });
        });
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IAuthenticationService, AuthenticationService>();
    }

    private static void AddIdentityConfig(this IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<IdentityDbAppContext>().AddDefaultTokenProviders();
    }

    private static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtOptions = configuration.GetSection(JWTOptions.GetSectionName()).Get<JWTOptions>();
        RsaSecurityKey rsaSecurityKey = null;
        TokenValidationParameters tokenValidationParameters = null;

        if (File.Exists(jwtOptions.PrivatekeyPath))
        {
            var rsaKey = RSA.Create();
            string xmlKey = File.ReadAllText(jwtOptions.PrivatekeyPath);
            rsaKey.FromXmlString(xmlKey);
            rsaSecurityKey = new RsaSecurityKey(rsaKey);
            tokenValidationParameters = GetTokenValidationParameters(jwtOptions, rsaSecurityKey);
        }
        else
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey));
            tokenValidationParameters = GetTokenValidationParameters(jwtOptions, symmetricSecurityKey);
        }


        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(o =>
        {
            o.RequireHttpsMetadata = false;
            o.SaveToken = false;
            o.TokenValidationParameters = tokenValidationParameters;
            o.Events = new JwtBearerEvents()
            {
                OnAuthenticationFailed = context =>
                {
                    var errorResult = JsonConvert.SerializeObject(new ServiceResponse<string>("Unauthorized: " + context.Exception.ToString()));
                    context.Response.WriteAsync(errorResult);
                    context.Fail("Unauthorized");
                    return Task.CompletedTask;
                },
                OnChallenge = context =>
                {
                    context.HandleResponse();
                    var result = JsonConvert.SerializeObject(new ServiceResponse<string>("You are not Authorized"));
                    context.Response.WriteAsync(result);
                    return Task.CompletedTask;
                },
                OnForbidden = context =>
                {
                    var result = JsonConvert.SerializeObject(new ServiceResponse<string>("You are not authorized to access this resource"));
                    return context.Response.WriteAsync(result);
                },
            };
        });
    }

    private static TokenValidationParameters GetTokenValidationParameters(JWTOptions jwtOptions, SecurityKey securityKey)
    {
        return new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
            IssuerSigningKey = securityKey
        };
    }
}
