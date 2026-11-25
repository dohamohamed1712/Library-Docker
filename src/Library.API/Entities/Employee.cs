namespace Library.API.Entities;

public class Employee : BaseEntity
{
    public string FName { get; set; } = null!;
    public string LName { get; set; } = null!;
    public string? Address { get; set; }
    public decimal? Salary { get; set; }
    public string? Email { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
    public decimal? Bonus { get; set; }
    public int? SupervisorId { get; set; }
    public int? FloorId { get; set; }

    public Employee? Supervisor { get; set; }
    public ICollection<Employee> Subordinates { get; set; } = new List<Employee>();
    public Floor? Floor { get; set; }
    public User? UserRecord { get; set; }
    public ICollection<Borrow> Borrows { get; set; } = new List<Borrow>();
    public ICollection<Floor> ManagedFloors { get; set; } = new List<Floor>();
}
