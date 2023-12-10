namespace Company.BookManager.Domain.Abstractions;

public interface IDataAccess<T>
{
    IEnumerable<T> Get(T searchCriteria);
    T? GetById(int id);
    T Insert(T bookDetails);
    T Update(T bookDetails);
    T Delete(int id);
}