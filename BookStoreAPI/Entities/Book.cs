namespace BookStoreAPI.Entities
{
    public class Book
    {


        // Une prop mets a dispostion des accesseurs (getters et setters)
        // ceci est une property
        public int Id { get; set; }
        public required string Title { get; init; }
        public required AuthorDto Author { get; set; }
        public required Publisher Publisher { get; set; }
        public required GenreDto Genre { get; set; }
        public string Abstract { get; set; } = string.Empty;



    }

    public class Test
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Price { get; set; }
    }
}