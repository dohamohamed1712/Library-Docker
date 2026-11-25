namespace Library.API.Dtos.BookDtos;

public class CreateBookRequest
{
    public string Title { get; set; } = null!;
    public string ShelfCode { get; set; } = null!;
    public int PublisherId { get; set; }
    public int CategoryId { get; set; }
}

public class UpdateBookRequest
{
    public string Title { get; set; } = null!;
    public string ShelfCode { get; set; } = null!;
    public int PublisherId { get; set; }
    public int CategoryId { get; set; }
}

public class GetBookResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string ShelfCode { get; set; } = null!;
    public string? CategoryName { get; set; }
    public string? PublisherName { get; set; }
}
