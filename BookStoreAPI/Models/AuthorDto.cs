namespace BookStoreAPI.Models
{
    public class AuthorDto
    {
        public string LastName { get; init; } = string.Empty;

        public BookDto[] Book { get; set; } = default!;

    }
}