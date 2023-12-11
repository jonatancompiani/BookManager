namespace Company.BookManager.Domain.Abstractions;

public interface IDataAccess<T>
{
    Task<IEnumerable<T>> GetAsync(T searchCriteria);
    Task<T?> GetByIdAsync(int id);
    Task<T> InsertAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}