using Microsoft.EntityFrameworkCore;
using Company.BookManager.Domain.Entities;

namespace Company.BookManager.Infrastructure.Abstractions;

public interface IBookDataContext
{
    DbSet<Book> Books { get; set; }
    int SaveChanges();
}
    