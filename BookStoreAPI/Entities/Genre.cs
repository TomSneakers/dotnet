namespace BookStoreAPI.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class GenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}