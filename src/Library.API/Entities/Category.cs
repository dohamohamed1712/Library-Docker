namespace Library.API.Entities;

public class Category : BaseEntity
{
    public string CatName { get; set; } = null!;

    public ICollection<Book> Books { get; set; } = new List<Book>();
}
