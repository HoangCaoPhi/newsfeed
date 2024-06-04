using Microsoft.Extensions.DependencyInjection;

namespace Newsfeed.Application;

public static class ServiceExtensions
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatRToApp();
    }

    public static void AddMediatRToApp(this IServiceCollection services)
    {
        var assembly = typeof(IAssemblyMarker).Assembly;
        services.AddMediatR(configure =>
        {
            configure.RegisterServicesFromAssembly(assembly);
        });
    }
}
