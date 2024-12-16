namespace Todo.Data.Repository;

public interface IUnitOfWork : IDisposable
{
    ITodoItemRepository TodoItems { get; }
    Task<int> Complete();
}