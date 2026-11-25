using AutoMapper;
using Library.API.Dtos.AuthorDtos;
using Library.API.Dtos.BookDtos;
using Library.API.Dtos.CategoryDtos;
using Library.API.Dtos.EmployeeDtos;
using Library.API.Dtos.FloorDtos;
using Library.API.Dtos.PublisherDtos;
using Library.API.Dtos.ShelfDtos;
using Library.API.Dtos.UserDtos;
using Library.API.Entities;

namespace Library.API.Helper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, GetBookResponse>()
            .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.CatName))
            .ForMember(d => d.PublisherName, o => o.MapFrom(s => s.Publisher.Name));
        CreateMap<CreateBookRequest, Book>();
        CreateMap<UpdateBookRequest, Book>();

        CreateMap<Category, GetCategoryResponse>();
        CreateMap<CreateCategoryRequest, Category>();
        CreateMap<UpdateCategoryRequest, Category>();

        CreateMap<Publisher, GetPublisherResponse>();
        CreateMap<CreatePublisherRequest, Publisher>();
        CreateMap<UpdatePublisherRequest, Publisher>();

        CreateMap<Author, GetAuthorResponse>();
        CreateMap<CreateAuthorRequest, Author>();
        CreateMap<UpdateAuthorRequest, Author>();

        CreateMap<Floor, GetFloorResponse>();
        CreateMap<CreateFloorRequest, Floor>();
        CreateMap<UpdateFloorRequest, Floor>();

        CreateMap<Shelf, GetShelfResponse>();
        CreateMap<CreateShelfRequest, Shelf>();
        CreateMap<UpdateShelfRequest, Shelf>();

        CreateMap<Employee, GetEmployeeResponse>()
            .ForMember(d => d.FullName, o => o.MapFrom(s => s.FName + " " + s.LName));
        CreateMap<CreateEmployeeRequest, Employee>();
        CreateMap<UpdateEmployeeRequest, Employee>();

        CreateMap<User, GetUserResponse>()
            .ForMember(d => d.Phones, o => o.MapFrom(s => s.Phones.Select(p => p.Phone).ToList()));
        CreateMap<CreateUserRequest, User>()
            .ForMember(d => d.Phones, o => o.MapFrom(s => s.Phones.Select(p => new UserPhone { Phone = p })));
        CreateMap<UpdateUserRequest, User>();
    }
}
