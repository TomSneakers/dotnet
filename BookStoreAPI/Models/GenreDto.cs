
using System.Text.Json.Serialization;
using BookStoreAPI.Entities;

namespace BookStoreAPI.Models;
public class GenreDto
{
    public string Name { get; set; } = string.Empty;

    //[JsonIgnore]
    public ICollection<BookForViewDto> Books { get; set; } = new List<BookForViewDto>();

}