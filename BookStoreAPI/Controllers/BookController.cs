using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookStoreAPI.Entities;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;



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
        return Ok(books);
    }


    // Ceci est une annotation, elle permet de définir des métadonnées sur une méthode
    // ActionResult designe le type de retour de la méthode de controller d'api
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(int id)
    {

        // Vérifiez si le livre existe dans la base de données
        // TODO:
        Book? book = await _dbContext.Books.Include(a => a.Publisher).Include(a => a.Genre).FirstOrDefaultAsync(b => b.Id == id);

        if (book == null)
        {
            return NotFound();
        }
        Author? author = await _dbContext.Authors.FirstOrDefaultAsync(a => a.Id == book.AuthorId);
        var bookDto = _mapper?.Map<BookDto>(book); // Vérifier la nullité de _mapper
        if (bookDto == null)
        {
            return BadRequest();
        }
        bookDto.Author = _mapper?.Map<AuthorForBookDTO>(author);

        return Ok(bookDto);
    }

    //Methode Post
    //[Authorize]
    //[AllowAnonymous] // permet de ne pas avoir besoin d'être authentifié pour accéder à la méthode
    [HttpPost]
    [ProducesResponseType(201, Type = typeof(Book))]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Book>> PostBook([FromBody] Book book)
    {
        // we check if the parameter is null
        if (book == null)
        {
            return BadRequest();
        }
        // we check if the book already exists
        Book? addedBook = await _dbContext.Books.FirstOrDefaultAsync(b => b.Title == book.Title);
        if (addedBook != null)
        {
            return BadRequest("Book already exists");
        }
        else
        {
            // we add the book to the database
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();

            // we return the book
            return Created("api/book", book);

        }
    }

    //Methode Put
    [HttpPut("{id}")]
    // [ProducesResponseType(200, Type = typeof(Book))]
    // [ProducesResponseType(400)]
    // [ProducesResponseType(404)]
    public async Task<ActionResult<Book>> PutBook(int id, [FromBody] Book updatedBook)
    {
        // Vérifiez si le livre existe dans la base de données
        Book? existingBook = await _dbContext.Books.FindAsync(id);
        if (existingBook == null)
        {
            return NotFound();
        }

        // Créez un nouveau livre avec les nouvelles valeurs
        Book newBook = new Book
        {
            Id = existingBook.Id,
            Title = updatedBook.Title,
            //Author = updatedBook.Author,
            Abstract = updatedBook.Abstract,
            Publisher = existingBook.Publisher, // Add the Publisher property
            Genre = existingBook.Genre // Add the Genre property
        };

        // Mettez à jour les propriétés du livre existant avec les nouvelles valeurs
        _dbContext.Entry(existingBook).CurrentValues.SetValues(newBook);

        // Enregistrez les modifications dans la base de données
        await _dbContext.SaveChangesAsync();

        // Retournez une réponse OK avec le livre mis à jour
        return Ok(existingBook);
    }


    //Methode Delete
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteBook(int id)
    {
        // Vérifiez si le livre existe dans la base de données
        Book? existingBook = await _dbContext.Books.FindAsync(id);
        if (existingBook == null)
        {
            return NotFound();
        }

        // Supprimez le livre de la base de données
        _dbContext.Books.Remove(existingBook);
        await _dbContext.SaveChangesAsync();

        // Retournez une réponse OK avec le livre supprimé
        return Ok();
    }
}

