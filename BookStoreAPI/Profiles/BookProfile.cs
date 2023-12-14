using AutoMapper;
using BookStoreAPI.Entities;
using BookStoreAPI.Models;

namespace BookStoreAPI.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<Author, AuthorDto>().ReverseMap();
        CreateMap<Author, AuthorForBookDTO>();
        CreateMap<Publisher, PublisherDto>();
        CreateMap<Genre, GenreDto>();

        CreateMap<BookCreateRequestDto, Book>();
    }
}
