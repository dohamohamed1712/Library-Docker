namespace Library.API.Entities;

public class Floor : BaseEntity
{
    public int NumberOfBlocks { get; set; }
    public int? ManageId { get; set; }
    public DateTime? HiringDate { get; set; }

    public Employee? Manager { get; set; }
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    public ICollection<Shelf> Shelves { get; set; } = new List<Shelf>();
}
