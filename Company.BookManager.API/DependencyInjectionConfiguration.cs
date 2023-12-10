using Company.BookManager.Application;
using Company.BookManager.Infrastructure;
using Company.BookManager.API.Middlewares;

namespace Company.BookManager.API;

public static class DependencyInjectionConfiguration
{
    public static void ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .ConfigureApi()
            .ConfigureApplication()
            .ConfigureInfrastructure(configuration);
    }

    public static IServiceCollection ConfigureApi(this IServiceCollection services)
    {
        return services
            .AddScoped<ErrorHandlingMiddleware>();
    }
}
