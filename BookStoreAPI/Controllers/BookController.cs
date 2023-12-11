using System.Collections.Generic;
using BookStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;


namespace BookStoreAPI.Controllers; // BookStoreAPI est l'espace de nom racine de mon projet 



[ApiController]
public class BookController : ControllerBase
{
    //Methode GET
    [HttpGet]
    //Route permet de definir l'url de la methode
    [Route("api/books")]
    public ActionResult<List<Book>> GetBooks()
    {
        var books = new List<Book>
        {
            new() { Id = 1, Title = "Elon Musk", Author = "Elon musk" },
        };

        return books;
    }
    //Methode POST
    [HttpPost]
    //Route permet de definir l'url de la methode
    [Route("api/books")]
    public ActionResult<Book> CreateBook(Book book)
    {

        var newBook = new Book
        {
            Id = 2,
            Title = book.Title,
            Author = book.Author
        };

        return newBook;
    }

}
