using Company.BookManager.Domain.Abstractions;
using Company.BookManager.Domain.Entities;
using Company.BookManager.Infrastructure.Abstractions;

namespace Company.BookManager.Infrastructure.DataAccess;

public class BookDataAccess : IDataAccess<Book>
{
    private readonly IBookDataContext _dataContext;

    public BookDataAccess(IBookDataContext dataContext)
	{
        _dataContext = dataContext;
	}

    public async Task<Book?> GetByIdAsync(int id)
    {
        return _dataContext.Books.FirstOrDefault(x => x.Id == id);
    }

    public async Task<IEnumerable<Book>> GetAsync(Book searchCriteria)
    {
        return _dataContext
            .Books
            .Where(x=>
                (string.IsNullOrWhiteSpace(searchCriteria.Title) || (x.Title != null && x.Title.Contains(searchCriteria.Title)))
                && (string.IsNullOrWhiteSpace(searchCriteria.Auhor) || (x.Auhor != null &&x.Auhor.Contains(searchCriteria.Auhor)))
                && (searchCriteria.PublishYear == null || x.PublishYear == searchCriteria.PublishYear));
    }

    public async Task<Book> InsertAsync(Book bookDetails)
    {
        _dataContext.Books.Add(bookDetails);
        _dataContext.SaveChanges();
        return bookDetails;
    }

    public async Task<Book> UpdateAsync(Book bookDetails)
    {
        throw new NotImplementedException();
    }

    public async Task<Book> DeleteAsync(Book book)
    {
        _ = _dataContext.Books.Remove(book);
        _dataContext.SaveChanges();

        return book;
    }
}
