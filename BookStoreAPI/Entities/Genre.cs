using BookStoreAPI.Models;

namespace BookStoreAPI.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Incorpore une liste de Book BookForViewDto

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }

}