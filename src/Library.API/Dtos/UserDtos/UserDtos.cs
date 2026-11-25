namespace Library.API.Dtos.UserDtos;

public class CreateUserRequest
{
    public string Name { get; set; } = null!;
    public string? Email { get; set; }
    public int RecordId { get; set; }
    public List<string> Phones { get; set; } = new();
}

public class UpdateUserRequest
{
    public string Name { get; set; } = null!;
    public string? Email { get; set; }
}

public class GetUserResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Email { get; set; }
    public int RecordId { get; set; }
    public List<string> Phones { get; set; } = new();
}
