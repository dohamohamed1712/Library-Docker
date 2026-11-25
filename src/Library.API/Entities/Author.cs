namespace Library.API.Entities;

public class Author : BaseEntity
{
    public string Name { get; set; } = null!;

    public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
}
