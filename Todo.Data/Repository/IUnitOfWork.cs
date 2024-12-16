namespace Todo.Data.Repository;

public interface IUnitOfWork : IDisposable
{
    IBookingRepository Bookings { get; }
    IConcertRepository Concerts{ get; }
    IPerformanceRepository Performances{ get; }

    Task<int> Complete();
}