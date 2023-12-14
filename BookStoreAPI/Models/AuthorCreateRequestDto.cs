using BookStoreAPI.Entities;
namespace BookStoreAPI.Models
{
    public class AuthorCreateRequestDto
    {
        public int Id { get; set; }
        public required string FirstName { get; init; }
        public string? LastName { get; set; }



    }
}
