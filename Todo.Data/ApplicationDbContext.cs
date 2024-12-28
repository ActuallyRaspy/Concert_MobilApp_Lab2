using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Todo.Data.Entity;

namespace Todo.Data;

public class ApplicationDbContext : DbContext
{
    public virtual DbSet<Concert> Concerts{ get; set; }
    public virtual DbSet<Performance> Performances { get; set; }
    public virtual DbSet<Booking> Bookings { get; set; }


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

        SetAttributes(modelBuilder);
        SeedData(modelBuilder);
    }

    private void SetAttributes(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Concert>(entity =>
        {
            entity.HasKey(c => c.ID);
            entity.Property(c => c.ID).IsRequired().HasDefaultValueSql("NEWID()"); //Auto increment through the database
            entity.Property(c => c.Title).HasMaxLength(50).IsRequired();
            entity.Property(c => c.Description).HasMaxLength(500).IsRequired();

            // Collection Navigation
            entity.HasMany(c => c.Performances)
                  .WithOne(p => p.Concert)
                  .HasForeignKey(p => p.ConcertID)
                  .OnDelete(DeleteBehavior.Cascade); // Ensure performances are deleted if concert is removed
        });

        modelBuilder.Entity<Performance>(entity =>
        {
            entity.HasKey(p => p.ID);
            entity.Property(p => p.ID).IsRequired().HasDefaultValueSql("NEWID()"); //Auto increment through the database
            entity.Property(p => p.Date).IsRequired();
            entity.Property(p => p.Location).HasMaxLength(500).IsRequired();

            // Foreign Key Configuration
            entity.Property(p => p.ConcertID).IsRequired();
            entity.HasOne(p => p.Concert)
                  .WithMany(c => c.Performances)
                  .HasForeignKey(p => p.ConcertID)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(b => b.ID);
            entity.Property(b => b.ID).IsRequired().HasDefaultValueSql("NEWID()"); //Auto increment through the database
            entity.Property(b => b.Name).HasMaxLength(25).IsRequired();
            entity.Property(b => b.Email).HasMaxLength(500).IsRequired();

            // Foreign Key Configuration
            entity.Property(b => b.PerformanceID).IsRequired();
            entity.HasOne(b => b.Performance)
                  .WithMany(b => b.Bookings) // 
                  .HasForeignKey(b => b.PerformanceID)
                  .OnDelete(DeleteBehavior.Cascade); // Ensure bookings are deleted if performance is removed
        });
    }

    private void SeedData(ModelBuilder builder)
    {
        var concert1 = new Concert
        {
            ID = "0",
            Title = "Rock the Night",
            Description = "A high-energy rock concert featuring various rock bands.",
        };

        var concert2 = new Concert
        {
            ID = "1",
            Title = "Symphony in the Park",
            Description = "An open-air classical music event featuring the New York Philharmonic.",
        };

        var concert3 = new Concert
        {
            ID = "2",
            Title = "Jazz on the Lake",
            Description = "A jazz concert near the beautiful Lake Tahoe.",
        };


        builder.Entity<Concert>().HasData(concert1, concert2, concert3);

        // Seed data for Performances
        var performance1 = new Performance
        {
            ID = "0",
            Date = DateTime.Parse("2024-04-01"),
            Location = "Madison Square Garden, NYC",
            ConcertID = concert1.ID,
        };

        var performance2 = new Performance
        {
            ID = "1",
            Date = DateTime.Parse("2024-05-15"),
            Location = "Central Park, NYC",
            ConcertID = concert2.ID, 
        };

        var performance3 = new Performance
        {
            ID = "2",
            Date = DateTime.Parse("2024-06-10"),
            Location = "Lake Tahoe, CA",
            ConcertID = concert3.ID, 
        };

        var performance4 = new Performance
        {
            ID = "3",
            Date = DateTime.Parse("2024-07-20"),
            Location = "The Fillmore, San Francisco",
            ConcertID = concert1.ID, 
        };

        var performance5 = new Performance
        {
            ID = "4",
            Date = DateTime.Parse("2024-08-05"),
            Location = "Staples Center, LA",
            ConcertID = concert2.ID, 
        };

        var performance6 = new Performance
        {
            ID = "5",
            Date = DateTime.Parse("2024-09-01"),
            Location = "Royal Albert Hall, London",
            ConcertID = concert3.ID, 
        };

        var performance7 = new Performance
        {
            ID = "6",
            Date = DateTime.Parse("2024-10-10"),
            Location = "Berghain, Berlin",
            ConcertID = concert1.ID, 
        };
        builder.Entity<Performance>().HasData(performance1, performance2, performance3, performance4, performance5, performance6, performance7);
        
        var booking1 = new Booking
        {
            ID = "0",
            Name = "John Doe",
            Email = "johndoe@example.com",
            PerformanceID = performance1.ID, 
        };

        var booking2 = new Booking
        {
            ID = "1",
            Name = "Jane Smith",
            Email = "janesmith@example.com",
            PerformanceID = performance2.ID, 
        };

        var booking3 = new Booking
        {
            ID = "2",
            Name = "Alice Johnson",
            Email = "alicejohnson@example.com",
            PerformanceID = performance3.ID, 
        };

        var booking4 = new Booking
        {
            ID = "3",
            Name = "Bob Williams",
            Email = "bobwilliams@example.com",
            PerformanceID = performance4.ID, 
        };

        var booking5 = new Booking
        {
            ID = "4",
            Name = "Charlie Brown",
            Email = "charliebrown@example.com",
            PerformanceID = performance5.ID,
        };

        var booking6 = new Booking
        {
            ID = "5",
            Name = "Diana Prince",
            Email = "dianaprince@example.com",
            PerformanceID = performance6.ID, 
            Performance = performance6 
        };

        var booking7 = new Booking
        {
            ID = "6",
            Name = "Edward Green",
            Email = "edwardgreen@example.com",
            PerformanceID = performance7.ID, 
        };

        var booking8 = new Booking
        {
            ID = "7",
            Name = "Fiona Lee",
            Email = "fionalee@example.com",
            PerformanceID = performance1.ID, 
        };

        var booking9 = new Booking
        {
            ID = "8",
            Name = "George Harris",
            Email = "georgeharris@example.com",
            PerformanceID = performance2.ID,
        };

        var booking10 = new Booking
        {
            ID = "9",
            Name = "Hannah King",
            Email = "hannahking@example.com",
            PerformanceID = performance3.ID, 
        };

        var booking11 = new Booking
        {
            ID = "10",
            Name = "Ian White",
            Email = "ianwhite@example.com",
            PerformanceID = performance4.ID, 
        };

        var booking12 = new Booking
        {
            ID = "11",
            Name = "Julia Black",
            Email = "juliablack@example.com",
            PerformanceID = performance5.ID, 
        };

        builder.Entity<Booking>().HasData(booking7, booking8, booking9, booking10, booking11, booking12);
    }
}