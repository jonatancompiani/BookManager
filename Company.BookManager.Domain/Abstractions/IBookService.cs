using Company.BookManager.Domain.Entities;
using Company.BookManager.Domain.Model;

namespace Company.BookManager.Domain.Abstractions;

public interface IBookService
{
    Task<IEnumerable<Book>> GetBooksAsync(Book searchCriteria);
    Task<Book?> GetBookAsync(int id);
    Task<Book> CreateBookAsync(Book bookDetails);
    Task UpdateBookAsync(BookUpdateDto bookDetails);
    Task DeleteBookAsync(Book book);
}
