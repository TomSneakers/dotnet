using System.ComponentModel.DataAnnotations;
using BookStoreAPI.Entities;

namespace BookStoreAPI.Models
{
    public class BookForViewDto
    {
        [Key]
        public string? Title { get; init; } = default!;

    }
}