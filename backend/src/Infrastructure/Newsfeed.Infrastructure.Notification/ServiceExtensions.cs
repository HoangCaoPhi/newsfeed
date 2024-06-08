using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newsfeed.Infrastructure.Persistence.Options;

namespace Newsfeed.Infrastructure.Notification;
public static class ServiceExtensions
{
    public static void AddInfrastructureNotificationLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddNotificationDbContext(configuration);
    }

    private static void AddNotificationDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<NotificationDbContext>(options =>
        {
            var databaseMySqlOptions = configuration.GetSection(MySQLOptions.GetSectionName()).Get<MySQLOptions>();
            options.UseMySQL(databaseMySqlOptions.ConnectionString, dbOptions =>
            {
                dbOptions.EnableRetryOnFailure(databaseMySqlOptions.EnableRetryOnFailure);
            });
        });
    }
}
