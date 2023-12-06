namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(ICacheApplicationService<>), typeof(CacheApplicationService<>));

        return services;
    }
}
