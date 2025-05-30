﻿namespace Todo.Data.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext context;

    public IBookingRepository Bookings { get; private set; }
    public IConcertRepository Concerts{ get; private set; }
    public IPerformanceRepository Performances { get; private set; }


    public UnitOfWork(ApplicationDbContext context)
    {
        this.context = context;
        Bookings = new BookingRepository(context);
        Concerts = new ConcertRepository(context);
        Performances = new PerformanceRepository(context);
    }

    public async Task<int> Complete()
    {
        return await context.SaveChangesAsync();
    }

    public void Dispose()
    {
        context.Dispose();
    }
}