using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Data.Entity;

namespace Todo.Data.Repository
{
    public class ConcertRepository : Repository<Concert>, IConcertRepository
    {
        public ApplicationDbContext DbContext => Context as ApplicationDbContext;

        public ConcertRepository(ApplicationDbContext context)
        : base(context)
        {
        }

        public async Task<bool> DoesItemExist(string id)
        {
            return await DbContext.Concerts.FindAsync(id) != null;
        }

        public async Task<Concert?> Find(string id)
        {
            return await DbContext.Concerts.FindAsync(id);
            //return await DbContext.TodoItems.FirstOrDefaultAsync(item => item.ID == id);
        }

        public void Update(Concert item)
        {
            Concert? existingItem = DbContext.Concerts.Find(item.ID);
            if (existingItem is not null)
                DbContext.Concerts.Remove(existingItem);
            DbContext.Concerts.Add(item);
        }

        public void Delete(string id)
        {
            Concert? todoItem = DbContext.Concerts.Find(id);
            if (todoItem is not null)
                DbContext.Concerts.Remove(todoItem);
        }   
    }
}
