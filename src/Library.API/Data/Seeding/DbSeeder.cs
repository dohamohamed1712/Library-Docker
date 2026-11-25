using Library.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Data.Seeding;

public static class DbSeeder
{
    public static async Task SeedAsync(LibraryDbContext context)
    {
        if (await context.Floors.AnyAsync())
        {
            return;
        }

        var floors = new List<Floor>
        {
            new() { NumberOfBlocks = 4 },
            new() { NumberOfBlocks = 3 },
            new() { NumberOfBlocks = 5 },
            new() { NumberOfBlocks = 2 },
            new() { NumberOfBlocks = 3 }
        };
        await context.Floors.AddRangeAsync(floors);
        await context.SaveChangesAsync();

        var ali = new Employee { FName = "Ali", LName = "Hassan", Address = "Cairo", Salary = 6000m, Email = "ali.hassan@lib.com", DateOfBirth = new DateTime(1985, 2, 10), PhoneNumber = "01011111111", Bonus = 300m, Floor = floors[0] };
        var mohamed = new Employee { FName = "Mohamed", LName = "Nabil", Address = "Alex", Salary = 7000m, Email = "mohamed.nabil@lib.com", DateOfBirth = new DateTime(1988, 5, 14), PhoneNumber = "01022222222", Bonus = 200m, Supervisor = ali, Floor = floors[1] };
        var sara = new Employee { FName = "Sara", LName = "Kamal", Address = "Cairo", Salary = 5500m, Email = "sara.kamal@lib.com", DateOfBirth = new DateTime(1990, 7, 1), PhoneNumber = "01033333333", Bonus = 150m, Supervisor = ali, Floor = floors[2] };
        var omar = new Employee { FName = "Omar", LName = "Amr", Address = "Alex", Salary = 6500m, Email = "omar.amr@lib.com", DateOfBirth = new DateTime(1991, 3, 3), PhoneNumber = "01055555555", Bonus = 250m, Supervisor = mohamed, Floor = floors[3] };
        var mona = new Employee { FName = "Mona", LName = "Adel", Address = "Cairo", Salary = 5200m, Email = "mona.adel@lib.com", DateOfBirth = new DateTime(1989, 6, 6), PhoneNumber = "01088888888", Bonus = 400m, Supervisor = sara, Floor = floors[4] };

        await context.Employees.AddRangeAsync(ali, mohamed, sara, omar, mona);
        await context.SaveChangesAsync();

        floors[0].ManageId = ali.Id;
        floors[0].HiringDate = new DateTime(2019, 1, 1);
        floors[1].ManageId = mohamed.Id;
        floors[1].HiringDate = new DateTime(2020, 3, 15);
        floors[2].ManageId = sara.Id;
        floors[2].HiringDate = new DateTime(2018, 6, 1);
        floors[3].ManageId = omar.Id;
        floors[3].HiringDate = new DateTime(2021, 2, 20);
        floors[4].ManageId = mona.Id;
        floors[4].HiringDate = new DateTime(2017, 9, 9);
        await context.SaveChangesAsync();

        var categories = new List<Category>
        {
            new() { CatName = "Programming" },
            new() { CatName = "Fiction" },
            new() { CatName = "History" },
            new() { CatName = "Science" }
        };
        var publishers = new List<Publisher>
        {
            new() { Name = "HarperCollins" },
            new() { Name = "Penguin Books" },
            new() { Name = "OReilly Media" },
            new() { Name = "Pearson" }
        };
        var authors = new List<Author>
        {
            new() { Name = "Robert Martin" },
            new() { Name = "J.K. Rowling" },
            new() { Name = "Yuval Noah Harari" },
            new() { Name = "Martin Fowler" },
            new() { Name = "Isaac Asimov" }
        };
        var shelves = new List<Shelf>
        {
            new() { Code = "A1", Floor = floors[0] },
            new() { Code = "A2", Floor = floors[0] },
            new() { Code = "B1", Floor = floors[1] },
            new() { Code = "C1", Floor = floors[2] },
            new() { Code = "D1", Floor = floors[3] }
        };

        await context.Categories.AddRangeAsync(categories);
        await context.Publishers.AddRangeAsync(publishers);
        await context.Authors.AddRangeAsync(authors);
        await context.Shelves.AddRangeAsync(shelves);
        await context.SaveChangesAsync();

        var books = new List<Book>
        {
            new() { Title = "Clean Code", Shelf = shelves[0], Publisher = publishers[2], Category = categories[0] },
            new() { Title = "Refactoring", Shelf = shelves[1], Publisher = publishers[2], Category = categories[0] },
            new() { Title = "Design Patterns", Shelf = shelves[0], Publisher = publishers[3], Category = categories[0] },
            new() { Title = "Harry Potter", Shelf = shelves[2], Publisher = publishers[0], Category = categories[1] },
            new() { Title = "Sapiens", Shelf = shelves[3], Publisher = publishers[0], Category = categories[2] },
            new() { Title = "Foundation", Shelf = shelves[4], Publisher = publishers[1], Category = categories[3] }
        };

        books[0].BookAuthors.Add(new BookAuthor { Author = authors[0] });
        books[1].BookAuthors.Add(new BookAuthor { Author = authors[0] });
        books[1].BookAuthors.Add(new BookAuthor { Author = authors[3] });
        books[2].BookAuthors.Add(new BookAuthor { Author = authors[3] });
        books[3].BookAuthors.Add(new BookAuthor { Author = authors[1] });
        books[4].BookAuthors.Add(new BookAuthor { Author = authors[2] });
        books[5].BookAuthors.Add(new BookAuthor { Author = authors[4] });

        await context.Books.AddRangeAsync(books);
        await context.SaveChangesAsync();

        var users = new List<User>
        {
            new() { Name = "Sara Youssef", Email = "sara.y@mail.com", Employee = ali },
            new() { Name = "Karim Adel", Email = "karim.a@mail.com", Employee = mohamed },
            new() { Name = "Ahmed Reda", Email = "ahmed.r@mail.com", Employee = sara },
            new() { Name = "Salma Hossam", Email = "salma.h@mail.com", Employee = omar },
            new() { Name = "Nada Ibrahim", Email = null, Employee = mona }
        };
        users[0].Phones.Add(new UserPhone { Phone = "01111111111" });
        users[0].Phones.Add(new UserPhone { Phone = "01111111112" });
        users[1].Phones.Add(new UserPhone { Phone = "01122222222" });
        users[2].Phones.Add(new UserPhone { Phone = "01133333333" });

        await context.Users.AddRangeAsync(users);
        await context.SaveChangesAsync();

        var borrows = new List<Borrow>
        {
            new() { Employee = ali, Book = books[0], User = users[0], DateBorrowed = new DateTime(2026, 1, 10), DueDate = new DateTime(2026, 1, 24), AmountOfMoney = 20m },
            new() { Employee = mohamed, Book = books[3], User = users[1], DateBorrowed = new DateTime(2026, 2, 1), DueDate = new DateTime(2026, 2, 15), AmountOfMoney = 15m },
            new() { Employee = sara, Book = books[4], User = users[2], DateBorrowed = new DateTime(2026, 2, 20), DueDate = new DateTime(2026, 3, 6), AmountOfMoney = 25m }
        };

        await context.Borrows.AddRangeAsync(borrows);
        await context.SaveChangesAsync();
    }
}
