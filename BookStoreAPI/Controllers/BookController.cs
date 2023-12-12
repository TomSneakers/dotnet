using System.Collections.Generic;
using BookStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        // [Route("api/books")]

        public ActionResult<List<Book>> GetBooks()
        {
            return _books;
        }


        // POST Method
        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            // book.Id = GenerateNewId();

            // _books.Add(book);

            return CreatedAtAction(nameof(GetBooks), new { id = book.Id });
        }

        // PUT Method
        [HttpPut]
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

        // DELETE Method
        [HttpDelete]
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