namespace Library.API.Dtos.ShelfDtos;

public class CreateShelfRequest
{
    public string Code { get; set; } = null!;
    public int FloorNum { get; set; }
}

public class UpdateShelfRequest
{
    public int FloorNum { get; set; }
}

public class GetShelfResponse
{
    public string Code { get; set; } = null!;
    public int FloorNum { get; set; }
}
