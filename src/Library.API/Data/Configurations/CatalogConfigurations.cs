using Library.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.API.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("ID");
        builder.Property(c => c.CatName).HasColumnName("Cat_name").HasMaxLength(50).IsRequired();
    }
}

public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.ToTable("Publishers");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("ID");
        builder.Property(p => p.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
    }
}

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("Authors");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).HasColumnName("ID");
        builder.Property(a => a.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
    }
}

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).HasColumnName("ID");
        builder.Property(b => b.Title).HasColumnName("title").HasMaxLength(150).IsRequired();
        builder.Property(b => b.ShelfCode).HasColumnName("shcode").HasMaxLength(10).IsRequired();
        builder.Property(b => b.PublisherId).HasColumnName("pid").IsRequired();
        builder.Property(b => b.CategoryId).HasColumnName("cat_id").IsRequired();

        builder.HasOne(b => b.Shelf)
               .WithMany(s => s.Books)
               .HasForeignKey(b => b.ShelfCode)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(b => b.Publisher)
               .WithMany(p => p.Books)
               .HasForeignKey(b => b.PublisherId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(b => b.Category)
               .WithMany(c => c.Books)
               .HasForeignKey(b => b.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

public class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
{
    public void Configure(EntityTypeBuilder<BookAuthor> builder)
    {
        builder.ToTable("BookAuthors");
        builder.HasKey(ba => new { ba.BookId, ba.AuthorId });
        builder.Property(ba => ba.BookId).HasColumnName("book_id");
        builder.Property(ba => ba.AuthorId).HasColumnName("aid");

        builder.HasOne(ba => ba.Book)
               .WithMany(b => b.BookAuthors)
               .HasForeignKey(ba => ba.BookId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ba => ba.Author)
               .WithMany(a => a.BookAuthors)
               .HasForeignKey(ba => ba.AuthorId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

public class BorrowConfiguration : IEntityTypeConfiguration<Borrow>
{
    public void Configure(EntityTypeBuilder<Borrow> builder)
    {
        builder.ToTable("Borrows");
        builder.HasKey(b => new { b.EmployeeId, b.BookId, b.UserId, b.DateBorrowed });
        builder.Property(b => b.EmployeeId).HasColumnName("Emp_id");
        builder.Property(b => b.BookId).HasColumnName("book_id");
        builder.Property(b => b.UserId).HasColumnName("SSN");
        builder.Property(b => b.DateBorrowed).HasColumnName("date_borrowed").HasColumnType("date");
        builder.Property(b => b.DueDate).HasColumnName("due_date").HasColumnType("date");
        builder.Property(b => b.AmountOfMoney).HasColumnName("amountofmoney").HasColumnType("decimal(10,2)");

        builder.HasOne(b => b.Employee)
               .WithMany(e => e.Borrows)
               .HasForeignKey(b => b.EmployeeId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(b => b.Book)
               .WithMany(bk => bk.Borrows)
               .HasForeignKey(b => b.BookId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(b => b.User)
               .WithMany(u => u.Borrows)
               .HasForeignKey(b => b.UserId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
