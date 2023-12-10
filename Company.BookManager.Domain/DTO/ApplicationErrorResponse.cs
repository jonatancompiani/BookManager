namespace Company.BookManager.Domain.DTO;

public record ApplicationErrorResponse(int StatusCode, string Message, string? Details);