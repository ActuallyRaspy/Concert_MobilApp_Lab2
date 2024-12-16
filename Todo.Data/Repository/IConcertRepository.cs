using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Data.Entity;

namespace Todo.Data.Repository
{
    public interface IConcertRepository : IRepository<Concert>
    {
        Task<bool> DoesItemExist(string id);
        Task<Concert?> Find(string id);
        void Update(Concert item);
        void Delete(string id);
    }
}
