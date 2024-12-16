using Todo.Data.Entity;

namespace Todo.Data.Repository;

public interface ITodoItemRepository : IRepository<Booking>
{
    Task<bool> DoesItemExist(string id);
    Task<Booking?> Find(string id);
    void Update(Booking item);
    void Delete(string id);
}