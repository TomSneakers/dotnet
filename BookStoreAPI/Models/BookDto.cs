using System.ComponentModel.DataAnnotations;
using BookStoreAPI.Entities;

namespace BookStoreAPI.Models
{
    public class BookDto
    {
        public string Title { get; init; } = default!;

        [MaxLength(15)]
        public AuthorDto? Author { get; set; } = default!;

        public PublisherDto? Publisher { get; set; } = default!;
    }
}