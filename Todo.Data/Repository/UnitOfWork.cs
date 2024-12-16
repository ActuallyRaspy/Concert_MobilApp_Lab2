namespace Todo.Data.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext context;

    public ITodoItemRepository TodoItems { get; private set; }

    public UnitOfWork(ApplicationDbContext context)
    {
        this.context = context;
        TodoItems = new BookingRepository(context);
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