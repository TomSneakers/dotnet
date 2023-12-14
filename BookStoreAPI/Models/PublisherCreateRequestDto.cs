using BookStoreAPI.Entities;
namespace BookStoreAPI.Models
{
    public class PublisherCreateRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;


    }
}
