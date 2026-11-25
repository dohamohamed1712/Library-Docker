using AutoMapper;
using Library.API.Dtos.BookDtos;
using Library.API.Entities;
using Library.API.Repositories;
using Library.API.Results;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Services;

public class BookService : GenericService<Book, GetBookResponse, CreateBookRequest, UpdateBookRequest>
{
    private readonly IGenericRepository<Book> _books;

    public BookService(IGenericRepository<Book> repository, IMapper mapper) : base(repository, mapper)
    {
        _books = repository;
    }

    public override async Task<GenericResult<GetBookResponse>> GetByIdAsync(params object[] key)
    {
        var id = (int)key[0];
        var book = await _books.Query()
            .AsNoTracking()
            .Include(b => b.Category)
            .Include(b => b.Publisher)
            .Include(b => b.Shelf)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (book is null)
        {
            return GenericResult<GetBookResponse>.Fail("Not found");
        }

        return GenericResult<GetBookResponse>.Ok(Mapper.Map<GetBookResponse>(book), "Retrieved successfully");
    }
}
