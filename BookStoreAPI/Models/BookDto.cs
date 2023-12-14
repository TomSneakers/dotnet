using System.ComponentModel.DataAnnotations;
using BookStoreAPI.Entities;

namespace BookStoreAPI.Models
{
    public class BookDto
    {
        public string Title { get; init; } = default!;

        [MaxLength(15)]
        public AuthorForBookDTO? Author { get; set; } = default!;

        public PublisherForBookDTO? Publisher { get; set; } = default!;
        public GenreForBookDTO? Genre { get; set; } = default!;
    }
}