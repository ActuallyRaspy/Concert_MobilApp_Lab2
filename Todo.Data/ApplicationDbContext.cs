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
        //SeedData(modelBuilder);
    }

    private void SetAttributes(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Concert>(entity =>
        {
            entity.HasKey(c => c.ID);
            entity.Property(c => c.ID).IsRequired();
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
            entity.Property(p => p.ID).IsRequired();
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
            entity.Property(b => b.ID).IsRequired();
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

    //private void SeedData(ModelBuilder builder)
    //{
    //    var todoItem1 = new Booking
    //    {
    //        ID = "6bb8a868-dba1-4f1a-93b7-24ebce87e243",
    //        Name = "Learn app development",
    //        Notes = "Take Microsoft Learn Courses",
    //        Comments = "Maybe take Coursera Courses too?",
    //        Completed = true
    //    };

    //    var todoItem2 = new Booking
    //    {
    //        ID = "b94afb54-a1cb-4313-8af3-b7511551b33b",
    //        Name = "Develop apps",
    //        Notes = "Use Visual Studio and Visual Studio for Mac",
    //        Comments = "Maybe use Visual Studio Code instead?",
    //        Completed = false
    //    };

    //    var todoItem3 = new Booking
    //    {
    //        ID = "ecfa6f80-3671-4911-aabe-63cc442c1ecf",
    //        Name = "Publish apps",
    //        Notes = "All app stores",
    //        Completed = false
    //    };

    //    builder.Entity<Booking>().HasData(todoItem1, todoItem2, todoItem3);
    //}
}