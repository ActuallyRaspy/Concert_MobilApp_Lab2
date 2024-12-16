using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Data.Entity;

namespace Todo.Data.Repository
{
    public class PerformanceRepository : Repository<Performance>, IPerformanceRepository
    {
        public ApplicationDbContext DbContext => Context as ApplicationDbContext;

        public PerformanceRepository(ApplicationDbContext context)
        : base(context)
        {
        }

        public async Task<bool> DoesItemExist(string id)
        {
            return await DbContext.Performances.FindAsync(id) != null;
        }

        public async Task<Performance?> Find(string id)
        {
            return await DbContext.Performances.FindAsync(id);
            //return await DbContext.TodoItems.FirstOrDefaultAsync(item => item.ID == id);
        }

        public void Update(Performance item)
        {
            Performance? existingItem = DbContext.Performances.Find(item.ID);
            if (existingItem is not null)
                DbContext.Performances.Remove(existingItem);
            DbContext.Performances.Add(item);
        }

        public void Delete(string id)
        {
            Performance? todoItem = DbContext.Performances.Find(id);
            if (todoItem is not null)
                DbContext.Performances.Remove(todoItem);
        }
    }
}
