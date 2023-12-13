using AutoMapper;
using BookStoreAPI.Entities;
using BookStoreAPI.Models;

namespace BookStoreAPI.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<Author, AuthorDto>();
        CreateMap<Genre, GenreDto>();
        CreateMap<Publisher, PublisherDto>();
        CreateMap<BookCreateRequestDto, Book>();
    }
}
