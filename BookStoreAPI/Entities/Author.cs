using System.Collections.Generic;

namespace BookStoreAPI.Entities
{
    public class Author
    {


        // Une prop mets a dispostion des accesseurs (getters et setters)
        // ceci est une property
        public int Id { get; set; }
        public required string FirstName { get; init; }
        public string? LastName { get; set; }


        public ICollection<Book> Books { get; set; } = new List<Book>();


    }

    // public class AuthorDto
    // {
    //     public int Id { get; set; }
    //     public string FirstName { get; init; } = string.Empty;
    //     public string? LastName { get; set; }

    // }
}