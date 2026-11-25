namespace Library.API.Entities;

public class Shelf
{
    public string Code { get; set; } = null!;
    public int FloorNum { get; set; }

    public Floor Floor { get; set; } = null!;
    public ICollection<Book> Books { get; set; } = new List<Book>();
}
