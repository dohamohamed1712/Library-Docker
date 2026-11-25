using Library.API.Data;
using Library.API.Helper;
using Library.API.Repositories;
using Library.API.Services;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Extensions;

public static class ApplicationServiceExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LibraryDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddAutoMapper(cfg => { }, typeof(MappingProfile).Assembly);

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped(typeof(IGenericService<,,,>), typeof(GenericService<,,,>));

        services.AddScoped<IGenericService<Library.API.Entities.Book, Library.API.Dtos.BookDtos.GetBookResponse, Library.API.Dtos.BookDtos.CreateBookRequest, Library.API.Dtos.BookDtos.UpdateBookRequest>, BookService>();

        return services;
    }
}

