using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.Models;
public class PublisherDto
{
    public string Name { get; set; } = string.Empty;
    public ICollection<BookForViewDto> Books { get; set; } = new List<BookForViewDto>();

}