namespace Library.API.Entities;

public class Publisher : BaseEntity
{
    public string Name { get; set; } = null!;

    public ICollection<Book> Books { get; set; } = new List<Book>();
}
