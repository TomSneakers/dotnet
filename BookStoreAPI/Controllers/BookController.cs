
using BookStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BookStoreAPI.Models;


namespace BookStoreAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper? _mapper;

    public BookController(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<Book>>> GetBooks()
    {
        var books = await _dbContext.Books.ToListAsync();
        var bookDtos = _mapper?.Map<List<Book>>(books); // Vérifier la nullité de _mapper
        return Ok(bookDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(int id)
    {
        Book? book = await _dbContext.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        var bookDto = _mapper?.Map<Book>(book); // Vérifier la nullité de _mapper
        return Ok(bookDto);
    }

    [HttpPost]
    [ProducesResponseType(201, Type = typeof(Book))]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Book>> PostBook([FromBody] Book book)
    {
        if (book == null)
        {
            return BadRequest();
        }

        Book? addedBook = await _dbContext.Books.FirstOrDefaultAsync(b => b.Title == book.Title);
        if (addedBook != null)
        {
            return BadRequest("Book already exists");
        }
        else
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();

            var bookDto = _mapper?.Map<Book>(book); // Vérifier la nullité de _mapper
            return Created("api/book", bookDto);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Book>> PutBook(int id, [FromBody] Book updatedBook)
    {
        Book? existingBook = await _dbContext.Books.FindAsync(id);
        if (existingBook == null)
        {
            return NotFound();
        }

        Book newBook = new Book
        {
            Id = existingBook.Id,
            Title = updatedBook.Title,
            Author = updatedBook.Author,
            Abstract = updatedBook.Abstract,
            Publisher = existingBook.Publisher,
            Genre = existingBook.Genre
        };

        _dbContext.Entry(existingBook).CurrentValues.SetValues(newBook);
        await _dbContext.SaveChangesAsync();

        var updatedBookDto = _mapper?.Map<Book>(existingBook); // Vérifier la nullité de _mapper
        return Ok(updatedBookDto);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteBook(int id)
    {
        Book? existingBook = await _dbContext.Books.FindAsync(id);
        if (existingBook == null)
        {
            return NotFound();
        }

        _dbContext.Books.Remove(existingBook);
        await _dbContext.SaveChangesAsync();

        return Ok();
    }
}

