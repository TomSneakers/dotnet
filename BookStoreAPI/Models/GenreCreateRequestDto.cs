using BookStoreAPI.Entities;
namespace BookStoreAPI.Models
{
    public class GenreCreateRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

    }
}
