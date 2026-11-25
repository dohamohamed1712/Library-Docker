namespace Library.API.Dtos.PublisherDtos;

public class CreatePublisherRequest
{
    public string Name { get; set; } = null!;
}

public class UpdatePublisherRequest
{
    public string Name { get; set; } = null!;
}

public class GetPublisherResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}
