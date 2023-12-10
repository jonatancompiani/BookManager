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

    public Book? GetById(int id)
    {
        return _dataContext.Books.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<Book> Get(Book searchCriteria)
    {
        return _dataContext
            .Books
            .Where(x=>
                (string.IsNullOrWhiteSpace(searchCriteria.Title) || (x.Title != null && x.Title.Contains(searchCriteria.Title)))
                && (string.IsNullOrWhiteSpace(searchCriteria.Auhor) || (x.Auhor != null &&x.Auhor.Contains(searchCriteria.Auhor)))
                && (searchCriteria.PublishYear == null || x.PublishYear == searchCriteria.PublishYear));
    }

    public Book Insert(Book bookDetails)
    {
        _dataContext.Books.Add(bookDetails);
        _dataContext.SaveChanges();
        return bookDetails;
    }

    public Book Update(Book bookDetails)
    {
        throw new NotImplementedException();
    }

    public Book Delete(int id)
    {
        var itemToDelete =
            _dataContext
            .Books
            .FirstOrDefault(x => x.Id == id);

        if (itemToDelete is null)
        {
            throw new ArgumentException("Item Not Found");
        }

        _ = _dataContext.Books.Remove(itemToDelete);
        _dataContext.SaveChanges();

        return itemToDelete;
    }
}
