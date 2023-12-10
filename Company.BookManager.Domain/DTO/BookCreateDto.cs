namespace Company.BookManager.Domain.Model;

public record BookCreateDto(string Title, string Auhor, int PublishYear);