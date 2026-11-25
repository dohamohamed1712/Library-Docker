namespace Library.API.Dtos.FloorDtos;

public class CreateFloorRequest
{
    public int NumberOfBlocks { get; set; }
    public int? ManageId { get; set; }
    public DateTime? HiringDate { get; set; }
}

public class UpdateFloorRequest
{
    public int NumberOfBlocks { get; set; }
    public int? ManageId { get; set; }
    public DateTime? HiringDate { get; set; }
}

public class GetFloorResponse
{
    public int Id { get; set; }
    public int NumberOfBlocks { get; set; }
    public int? ManageId { get; set; }
    public DateTime? HiringDate { get; set; }
}
