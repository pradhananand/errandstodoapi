using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrandsTodoApi.Models;

namespace ErrandsTodoApi.Repositories
{
    public interface ITodoRepository : IDisposable
    {
        IEnumerable<TodoItem> GetAll();
        Task<TodoItem> Find(string key);
        void Add(TodoItem item);
        void Remove(string key);
        void Update(TodoItem item);
        void Save();
    }

}
