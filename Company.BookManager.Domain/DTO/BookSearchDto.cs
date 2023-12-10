namespace Company.BookManager.Domain.Model;

public record BookSearchDto(string? Title, string? Auhor, int? PublishYear);