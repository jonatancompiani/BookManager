using Company.BookManager.Domain.Entities;
using Company.BookManager.Domain.Model;

namespace Company.BookManager.Domain.Abstractions;

public interface IBookService
{
    IEnumerable<BookResponseDto> GetBooks(BookSearchDto searchCriteria);
    BookResponseDto? GetBook(int id);
    void CreateBook(BookCreateDto bookDetails);
    void UpdateBook(BookUpdateDto bookDetails);
    void DeleteBook(int id);
}
