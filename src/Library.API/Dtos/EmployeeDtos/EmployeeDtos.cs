namespace Library.API.Dtos.EmployeeDtos;

public class CreateEmployeeRequest
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
}

public class UpdateEmployeeRequest : CreateEmployeeRequest
{
}

public class GetEmployeeResponse
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public decimal? Salary { get; set; }
    public decimal? Bonus { get; set; }
    public int? FloorId { get; set; }
}
