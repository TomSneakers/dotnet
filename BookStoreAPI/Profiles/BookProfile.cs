using AutoMapper;
using BookStoreAPI.Entities;
using BookStoreAPI.Models;


namespace BookStoreAPI.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<BookCreateRequestDto, Book>();
        CreateMap<BookForViewDto, Book>().ReverseMap();

        CreateMap<Author, AuthorDto>().ReverseMap();
        CreateMap<Author, AuthorForBookDTO>();
        CreateMap<AuthorCreateRequestDto, Author>().ReverseMap();

        CreateMap<Publisher, PublisherDto>();
        CreateMap<PublisherCreateRequestDto, Publisher>();
        CreateMap<Publisher, PublisherForBookDTO>();

        CreateMap<Genre, GenreDto>().ReverseMap();
        CreateMap<GenreCreateRequestDto, Genre>().ReverseMap();
        CreateMap<Genre, GenreForBookDTO>();

    }

}
