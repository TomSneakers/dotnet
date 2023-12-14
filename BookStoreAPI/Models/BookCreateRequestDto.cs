namespace BookStoreAPI.Models
{
    public class BookCreateRequestDto
    {
        //ID
        public int Id { get; init; }
        public string Title { get; init; } = string.Empty;
        public int AuthorId { get; init; }
        public int GenreId { get; init; }
        public int PublisherId { get; init; }

    }
}
