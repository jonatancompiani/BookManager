using Company.BookManager.Domain.Abstractions;
using Company.BookManager.Domain.Entities;
using Company.BookManager.Domain.Mappers;
using Company.BookManager.Domain.Model;

namespace Company.BookManager.Application.Services;

public class BookService : IBookService
{
    private readonly IDataAccess<Book> _bookDataAccess;

    public BookService(IDataAccess<Book> bookDataAccess)
    {
        _bookDataAccess = bookDataAccess;
    }

    public IEnumerable<BookResponseDto> GetBooks(BookSearchDto searchCriteria)
    {
        return _bookDataAccess.Get(searchCriteria.ToEntity()).ToDto();
    }

    public BookResponseDto? GetBook(int id)
    {
        return _bookDataAccess.GetById(id)?.ToDto();
    }

    public void CreateBook(BookCreateDto bookDetails)
    {
        _ = _bookDataAccess.Insert(bookDetails.ToEntity());
    }

    public void UpdateBook(BookUpdateDto bookDetails)
    {
        throw new NotImplementedException();
    }

    public void DeleteBook(int id)
    {
        _ = _bookDataAccess.Delete(id);
    }
}