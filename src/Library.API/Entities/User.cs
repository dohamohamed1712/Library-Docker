namespace Library.API.Entities;

public class User : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Email { get; set; }
    public int RecordId { get; set; }

    public Employee Employee { get; set; } = null!;
    public ICollection<UserPhone> Phones { get; set; } = new List<UserPhone>();
    public ICollection<Borrow> Borrows { get; set; } = new List<Borrow>();
}
