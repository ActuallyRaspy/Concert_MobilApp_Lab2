using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Data.Entity;

namespace Todo.Data.Repository
{
    public interface IPerformanceRepository : IRepository<Performance>
    {
        Task<bool> DoesItemExist(string id);
        Task<Performance?> Find(string id);
        void Update(Performance item);
        void Delete(string id);
    }
}
