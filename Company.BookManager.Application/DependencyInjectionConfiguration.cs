using Microsoft.Extensions.DependencyInjection;
using Company.BookManager.Application.Services;
using Company.BookManager.Domain.Abstractions;

namespace Company.BookManager.Application;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services)
    {
        return services.AddScoped<IBookService, BookService>();
    }
}
