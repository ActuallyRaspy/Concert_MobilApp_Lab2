using Todo.Data.Entity;

namespace Todo.Data.Repository;

public class BookingRepository : Repository<Booking>, ITodoItemRepository
{
    public ApplicationDbContext DbContext => Context as ApplicationDbContext;

    public BookingRepository(ApplicationDbContext context)
    : base(context)
    {
    }

    public async Task<bool> DoesItemExist(string id)
    {
        return await DbContext.TodoItems.FindAsync(id) != null;
    }

    public async Task<Booking?> Find(string id)
    {
        return await DbContext.TodoItems.FindAsync(id);
        //return await DbContext.TodoItems.FirstOrDefaultAsync(item => item.ID == id);
    }

    public void Update(Booking item)
    {
        Booking? existingItem = DbContext.TodoItems.Find(item.ID);
        if (existingItem is not null)
            DbContext.TodoItems.Remove(existingItem);
        DbContext.TodoItems.Add(item);
    }

    public void Delete(string id)
    {
        Booking? todoItem = DbContext.TodoItems.Find(id);
        if (todoItem is not null)
            DbContext.TodoItems.Remove(todoItem);
    }
}