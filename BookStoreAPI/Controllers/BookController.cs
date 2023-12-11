using System.Collections.Generic;
using BookStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly List<Book> _books;

        public BookController()
        {
            _books = new List<Book>
            {
                new Book { Id = 1, Title = "Elon Musk", Author = "Elon Musk" }
            };
        }

        // GET api/books
        [HttpGet]
        [Route("api/books")]

        public ActionResult<List<Book>> GetBooks()
        {
            return _books;
        }

        // POST api/books
        [HttpPost]
        [Route("api/books")]

        public ActionResult<Book> CreateBook(Book book)
        {
            var newBook = new Book
            {
                Id = GenerateNewId(),
                Title = book.Title,
                Author = book.Author
            };

            _books.Add(newBook);

            return newBook;
        }

        // PUT api/books/{id}
        [HttpPut]
        [Route("api/books")]

        public ActionResult<Book> UpdateBook(int id, Book book)
        {
            var existingBook = _books.Find(b => b.Id == id);

            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;

            return existingBook;
        }

        // DELETE api/books/{id}
        [HttpDelete]
        [Route("api/books")]

        public ActionResult DeleteBook(int id)
        {
            var existingBook = _books.Find(b => b.Id == id);

            if (existingBook == null)
            {
                return NotFound();
            }

            _books.Remove(existingBook);

            return Ok();
        }

        private int GenerateNewId()
        {
            return _books.Count + 1;
        }
    }
}