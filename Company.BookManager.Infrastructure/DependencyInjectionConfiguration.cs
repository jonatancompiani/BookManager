using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Company.BookManager.Domain.Abstractions;
using Company.BookManager.Domain.Entities;
using Company.BookManager.Infrastructure.Abstractions;
using Company.BookManager.Infrastructure.Data;
using Company.BookManager.Infrastructure.DataAccess;

namespace Company.BookManager.Infrastructure;

public static class DependencyInjectionConfiguration
{ 
    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return services
                .AddDbContext<BookDataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
                .AddScoped<IBookDataContext, BookDataContext>()
                .AddScoped<IDataAccess<Book>, BookDataAccess>();
    }
}