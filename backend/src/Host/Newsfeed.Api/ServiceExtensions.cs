using Mapster;
using MapsterMapper;
using System.Reflection;

namespace Newsfeed.Api;

public static class ServiceExtensions
{
    private readonly static Assembly[] Assemblies = AppDomain.CurrentDomain.GetAssemblies();
    public static void AddMappingMapster(this IServiceCollection services)
    {
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        typeAdapterConfig.Scan(Assemblies);
        services.AddSingleton(typeAdapterConfig);
        services.AddScoped<IMapper, ServiceMapper>();
    }
}
