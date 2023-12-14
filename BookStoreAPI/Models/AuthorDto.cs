using BookStoreAPI.Entities;
namespace BookStoreAPI.Models
{
    public class AuthorDto
    {
        public string LastName { get; init; } = string.Empty;

        //public Book Books { get; set; } = default!;
        public ICollection<BookForViewDto> Books { get; set; } = new List<BookForViewDto>();


    }
}
