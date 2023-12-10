using Microsoft.EntityFrameworkCore;
using Company.BookManager.Domain.Entities;
using Company.BookManager.Infrastructure.Abstractions;

namespace Company.BookManager.Infrastructure.Data;

public class BookDataContext : DbContext, IBookDataContext
{
	public BookDataContext() { }

    public BookDataContext(DbContextOptions<BookDataContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=Company;User Id=SA;Password=P4ssw0rd;TrustServerCertificate=true", builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(15), null);
            });
        }
    }

    public DbSet<Book> Books { get; set; }
}
