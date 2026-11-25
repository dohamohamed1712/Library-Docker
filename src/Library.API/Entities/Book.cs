namespace Library.API.Entities;

public class Book : BaseEntity
{
    public string Title { get; set; } = null!;
    public string ShelfCode { get; set; } = null!;
    public int PublisherId { get; set; }
    public int CategoryId { get; set; }

    public Shelf Shelf { get; set; } = null!;
    public Publisher Publisher { get; set; } = null!;
    public Category Category { get; set; } = null!;
    public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    public ICollection<Borrow> Borrows { get; set; } = new List<Borrow>();
}
