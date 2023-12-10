namespace Company.BookManager.Domain.Model;

public record BookUpdateDto(int Id, string Title, string Auhor, int PublishYear);