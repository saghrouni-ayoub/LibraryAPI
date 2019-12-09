﻿using AutoMapper;


namespace LibraryAPI.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Entities.Book, Models.BookWithConcatenateAuthorName>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src =>
                 $"{src.Author.FirstName} {src.Author.LastName}"));

            CreateMap<Entities.Book, Models.Book>()
                .ForMember(dest => dest.AuthorFirstName, opt => opt.MapFrom(src =>
                $"{src.Author.FirstName}"))
                .ForMember(dest => dest.AuthorLastName, opt => opt.MapFrom(src =>
                $"{src.Author.LastName}"));

            CreateMap<Models.BookForCreation, Entities.Book>();

            CreateMap<Models.BookForCreationWithAmountOfPages, Entities.Book>();
        }
    }
}
