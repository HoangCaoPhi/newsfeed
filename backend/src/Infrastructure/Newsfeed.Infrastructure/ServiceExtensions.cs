using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newsfeed.Application.Interfaces;
using Newsfeed.Infrastructure.Services;

namespace Newsfeed.Infrastructure;
public static class ServiceExtensions
{
    public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<INotificationService, NotificationService>();
        services.AddTransient<IFileService, FileService>();
        services.AddTransient<IEmailService, EmailService>();
    }
}
