namespace Company.BookManager.Domain.Entities;

public class Book
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Auhor { get; set; }
    public int? PublishYear { get; set; }
}

