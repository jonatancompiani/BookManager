using Company.BookManager.Domain.Abstractions;
using Company.BookManager.Domain.Entities;
using Company.BookManager.Domain.Model;

namespace Company.BookManager.Application.Services;

public class BookService : IBookService
{
    private readonly IDataAccess<Book> _bookDataAccess;

    public BookService(IDataAccess<Book> bookDataAccess)
    {
        _bookDataAccess = bookDataAccess;
    }

    public async Task<IEnumerable<Book>> GetBooksAsync(Book searchCriteria)
    {
        return await _bookDataAccess.GetAsync(searchCriteria);
    }

    public async Task<Book?> GetBookAsync(int id)
    {
        return await _bookDataAccess.GetByIdAsync(id);
    }

    public async Task<Book> CreateBookAsync(Book bookDetails)
    {
        return await _bookDataAccess.InsertAsync(bookDetails);
    }

    public async Task UpdateBookAsync(BookUpdateDto bookDetails)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteBookAsync(Book book)
    {
        _ = await _bookDataAccess.DeleteAsync(book);
    }
}