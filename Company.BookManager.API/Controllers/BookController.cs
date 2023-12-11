using Microsoft.AspNetCore.Mvc;
using Company.BookManager.Domain.Abstractions;
using Company.BookManager.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Company.BookManager.Domain.Mappers;

namespace Company.BookManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    public readonly IBookService _service;
    public BookController(IBookService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookResponseDto?>>> Get([FromQuery]BookSearchDto searchCriteria)
    {
        var result = await _service.GetBooksAsync(searchCriteria.ToEntity());

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookResponseDto?>> Get(int id)
    {
        var book = await _service.GetBookAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        return book.ToDto();
    }

    [HttpPost]
    public async Task<ActionResult<BookResponseDto>> Post([FromBody] BookCreateDto bookDetails)
    {
        var result = await _service.CreateBookAsync(bookDetails.ToEntity());

        return CreatedAtAction(nameof(Post), new { id = result.Id }, result);
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(BookUpdateDto bookDetails)
    {
        _service.UpdateBookAsync(bookDetails);
        return Accepted();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var book = await _service.GetBookAsync(id);
        if (book is null)
        {
            return NotFound();
        }

        _ = _service.DeleteBookAsync(book);

        return NoContent();
    }
}
