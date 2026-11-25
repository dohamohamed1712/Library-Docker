using Library.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.API.Data.Configurations;

public class FloorConfiguration : IEntityTypeConfiguration<Floor>
{
    public void Configure(EntityTypeBuilder<Floor> builder)
    {
        builder.ToTable("Floors");
        builder.HasKey(f => f.Id);
        builder.Property(f => f.Id).HasColumnName("floor_number");
        builder.Property(f => f.NumberOfBlocks).HasColumnName("NumberOfBlocks").IsRequired();
        builder.Property(f => f.ManageId).HasColumnName("manage_id");
        builder.Property(f => f.HiringDate).HasColumnName("Hiring_date").HasColumnType("date");

        builder.HasOne(f => f.Manager)
               .WithMany(e => e.ManagedFloors)
               .HasForeignKey(f => f.ManageId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("Emp_id");
        builder.Property(e => e.FName).HasColumnName("Fname").HasMaxLength(50).IsRequired();
        builder.Property(e => e.LName).HasColumnName("Lname").HasMaxLength(50).IsRequired();
        builder.Property(e => e.Address).HasColumnName("Address").HasMaxLength(100);
        builder.Property(e => e.Salary).HasColumnName("Salary").HasColumnType("decimal(10,2)");
        builder.Property(e => e.Email).HasColumnName("Email").HasMaxLength(100);
        builder.Property(e => e.DateOfBirth).HasColumnName("DateOfBirth").HasColumnType("date");
        builder.Property(e => e.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(20);
        builder.Property(e => e.Bonus).HasColumnName("Bouns").HasColumnType("decimal(10,2)");
        builder.Property(e => e.SupervisorId).HasColumnName("SupervisorId");
        builder.Property(e => e.FloorId).HasColumnName("floor_id");

        builder.HasOne(e => e.Supervisor)
               .WithMany(e => e.Subordinates)
               .HasForeignKey(e => e.SupervisorId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Floor)
               .WithMany(f => f.Employees)
               .HasForeignKey(e => e.FloorId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnName("SSN");
        builder.Property(u => u.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
        builder.Property(u => u.Email).HasColumnName("Email").HasMaxLength(100);
        builder.Property(u => u.RecordId).HasColumnName("record_id").IsRequired();

        builder.HasOne(u => u.Employee)
               .WithOne(e => e.UserRecord)
               .HasForeignKey<User>(u => u.RecordId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(u => u.RecordId).IsUnique();
    }
}

public class UserPhoneConfiguration : IEntityTypeConfiguration<UserPhone>
{
    public void Configure(EntityTypeBuilder<UserPhone> builder)
    {
        builder.ToTable("UserPhones");
        builder.HasKey(p => new { p.UserId, p.Phone });
        builder.Property(p => p.UserId).HasColumnName("user_ssn");
        builder.Property(p => p.Phone).HasColumnName("Phone").HasMaxLength(20);

        builder.HasOne(p => p.User)
               .WithMany(u => u.Phones)
               .HasForeignKey(p => p.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}

public class ShelfConfiguration : IEntityTypeConfiguration<Shelf>
{
    public void Configure(EntityTypeBuilder<Shelf> builder)
    {
        builder.ToTable("Shelves");
        builder.HasKey(s => s.Code);
        builder.Property(s => s.Code).HasColumnName("code").HasMaxLength(10);
        builder.Property(s => s.FloorNum).HasColumnName("floor_num").IsRequired();

        builder.HasOne(s => s.Floor)
               .WithMany(f => f.Shelves)
               .HasForeignKey(s => s.FloorNum)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
