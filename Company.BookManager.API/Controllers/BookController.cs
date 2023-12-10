using Microsoft.AspNetCore.Mvc;
using Company.BookManager.Domain.Abstractions;
using Company.BookManager.Domain.Model;

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
    public IActionResult Get([FromQuery]BookSearchDto searchCriteria)
    {
        return Ok(_service.GetBooks(searchCriteria));
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_service.GetBook(id));
    }

    [HttpPost]
    public IActionResult Post([FromBody] BookCreateDto bookDetails)
    {
        _service.CreateBook(bookDetails);
        return Accepted();
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(BookUpdateDto bookDetails)
    {
        _service.UpdateBook(bookDetails);
        return Accepted();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.DeleteBook(id);
        return NoContent();
    }
}
