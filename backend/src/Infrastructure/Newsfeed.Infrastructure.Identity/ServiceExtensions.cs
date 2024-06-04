using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newsfeed.Infrastructure.Persistence.Options;

namespace Newsfeed.Infrastructure.Identity;

public static class ServiceExtensions
{
    public static void AddInfrastructureIdentityLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbAppContext(configuration);
        services.AddRepositories();
    }

    private static void AddDbAppContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IdentityDbAppContext>(options =>
        {
            var databaseMySqlOptions = configuration.GetSection(MySQLOptions.ConfigName).Get<MySQLOptions>();
            options.UseMySQL(databaseMySqlOptions.ConnectionString, dbOptions =>
            {
                dbOptions.EnableRetryOnFailure(databaseMySqlOptions.EnableRetryOnFailure);
            });
        });
    }

    private static void AddRepositories(this IServiceCollection services)
    {

    }
}
