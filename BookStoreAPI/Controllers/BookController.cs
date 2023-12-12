
using BookStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BookStoreAPI.Controllers; // BookStoreAPI est l'espace de nom racine de mon projet 


// this designe la classe dans laquelle on se trouve


// Ceci est une annotation, elle permet de définir des métadonnées sur une classe
// Dans ce contexte elle permet de définir que la classe BookController est un contrôleur d'API
// On parle aussi de decorator / décorateur
[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{

    private readonly ApplicationDbContext _dbContext;

    public BookController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Ceci est une annotation, elle permet de définir des métadonnées sur une méthode
    // ActionResult designe le type de retour de la méthode de controller d'api
    [HttpGet]
    public async Task<ActionResult<List<Book>>> GetBooks()
    {
        var books = await _dbContext.Books.ToListAsync();
        return Ok(books);
    }
    // POST: api/Book
    // BODY: Book (JSON)
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
        if (addedBook == null)
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


    // PUT: api/Book/{id}
    // BODY: Book (JSON)
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
            Author = updatedBook.Author,
            Abstract = updatedBook.Abstract
        };

        // Mettez à jour les propriétés du livre existant avec les nouvelles valeurs
        _dbContext.Entry(existingBook).CurrentValues.SetValues(newBook);

        // Enregistrez les modifications dans la base de données
        await _dbContext.SaveChangesAsync();

        // Retournez une réponse OK avec le livre mis à jour
        return Ok(existingBook);
    }

    // DELETE: api/Book/{id}
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