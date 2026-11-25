namespace Library.API.Dtos.AuthorDtos;

public class CreateAuthorRequest
{
    public string Name { get; set; } = null!;
}

public class UpdateAuthorRequest
{
    public string Name { get; set; } = null!;
}

public class GetAuthorResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}
