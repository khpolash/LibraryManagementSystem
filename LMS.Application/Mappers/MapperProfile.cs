using AutoMapper;
using LMS.Application.ViewModels.VmEntities;
using LMS.SharedKernel.Entities;


namespace LMS.Application.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<VmAuthor, Author>().ReverseMap();

        CreateMap<VmBook, Book>()
            .ForMember(d => d.Author, opts => opts.Ignore());

        CreateMap<Book, VmBook>()
            .ForMember(d => d.AuthorName, opts => opts.MapFrom(src => src.Author.AuthorName));

        CreateMap<VmMember, Member>().ReverseMap();

        CreateMap<VmBorrowdBook, BorrowdBook>()
            .ForMember(d => d.Book, opts => opts.Ignore())
            .ForMember(d => d.Member, opts => opts.Ignore());

        CreateMap<BorrowdBook, VmBorrowdBook>()
            .ForMember(d => d.BookDropdown, opts => opts.Ignore())
            .ForMember(d => d.MamberDropdown, opts => opts.Ignore())
            .ForMember(d => d.MemberName, opts => opts.MapFrom(src => src.Member.FirstName))
            .ForMember(d => d.BookTitle, opts => opts.MapFrom(src => src.Book.Title));


        AllowNullCollections = true;
    }
}
