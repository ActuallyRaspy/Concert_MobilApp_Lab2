using Microsoft.EntityFrameworkCore;
using Todo.Data.Entity;

namespace Todo.Data;

public class ApplicationDbContext : DbContext
{
    public virtual DbSet<Booking> TodoItems { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    // EF Core Fluent API: https://www.learnentityframeworkcore.com/configuration/fluent-api
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Booking>()
        .HasKey(ti => ti.ID);

        modelBuilder.Entity<Booking>().Property<string>(ti => ti.ID)
        .HasColumnType("nchar(36)");

        modelBuilder.Entity<Booking>().Property(ti => ti.Name)
        .HasColumnType("nvarchar(25)")
        .HasMaxLength(25)
        .IsRequired();

        modelBuilder.Entity<Booking>().Property(ti => ti.Notes)
        .HasColumnType("nvarchar(500)")
        .HasMaxLength(500)
        .IsRequired();

        modelBuilder.Entity<Booking>().Property(ti => ti.Comments)
        .HasColumnType("nvarchar(500)")
        .HasMaxLength(500);

        modelBuilder.Entity<Booking>().Property(ti => ti.Completed)
        .HasColumnType("bit")
        .IsRequired();

        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder builder)
    {
        var todoItem1 = new Booking
        {
            ID = "6bb8a868-dba1-4f1a-93b7-24ebce87e243",
            Name = "Learn app development",
            Notes = "Take Microsoft Learn Courses",
            Comments = "Maybe take Coursera Courses too?",
            Completed = true
        };

        var todoItem2 = new Booking
        {
            ID = "b94afb54-a1cb-4313-8af3-b7511551b33b",
            Name = "Develop apps",
            Notes = "Use Visual Studio and Visual Studio for Mac",
            Comments = "Maybe use Visual Studio Code instead?",
            Completed = false
        };

        var todoItem3 = new Booking
        {
            ID = "ecfa6f80-3671-4911-aabe-63cc442c1ecf",
            Name = "Publish apps",
            Notes = "All app stores",
            Completed = false
        };

        builder.Entity<Booking>().HasData(todoItem1, todoItem2, todoItem3);
    }
}