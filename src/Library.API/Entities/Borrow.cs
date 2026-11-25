namespace Library.API.Entities;

public class Borrow
{
    public int EmployeeId { get; set; }
    public int BookId { get; set; }
    public int UserId { get; set; }
    public DateTime DateBorrowed { get; set; }
    public DateTime DueDate { get; set; }
    public decimal AmountOfMoney { get; set; }

    public Employee Employee { get; set; } = null!;
    public Book Book { get; set; } = null!;
    public User User { get; set; } = null!;
}
