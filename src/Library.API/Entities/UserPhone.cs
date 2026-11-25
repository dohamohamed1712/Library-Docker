namespace Library.API.Entities;

public class UserPhone
{
    public int UserId { get; set; }
    public string Phone { get; set; } = null!;

    public User User { get; set; } = null!;
}
