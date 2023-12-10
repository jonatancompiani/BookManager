using Riok.Mapperly.Abstractions;
using Company.BookManager.Domain.Entities;
using Company.BookManager.Domain.Model;

namespace Company.BookManager.Domain.Mappers;

[Mapper]
public static partial class BookMapper
{
    public static partial IEnumerable<BookResponseDto> ToDto(this IEnumerable<Book> car);
    public static partial BookResponseDto ToDto(this Book car);
    public static partial Book ToEntity(this BookSearchDto car);
    public static partial Book ToEntity(this BookCreateDto car);
}