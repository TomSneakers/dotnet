using AutoMapper;
using BookStoreAPI.Entities;
using BookStoreAPI.Models;


namespace BookStoreAPI.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        //Map pour Book
        CreateMap<Book, BookDto>();
        CreateMap<BookCreateRequestDto, Book>();
        CreateMap<BookForViewDto, Book>().ReverseMap();

        //Map pour Author
        CreateMap<Author, AuthorDto>().ReverseMap();
        CreateMap<Author, AuthorForBookDTO>();
        CreateMap<AuthorCreateRequestDto, Author>().ReverseMap();

        //Map pour Publisher
        CreateMap<Publisher, PublisherDto>();
        CreateMap<PublisherCreateRequestDto, Publisher>();
        CreateMap<Publisher, PublisherForBookDTO>();

        //Map pour Genre
        CreateMap<Genre, GenreDto>().ReverseMap();
        CreateMap<GenreCreateRequestDto, Genre>().ReverseMap();
        CreateMap<Genre, GenreForBookDTO>();

    }

}
