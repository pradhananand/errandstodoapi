using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrandsTodoApi.Models;

namespace ErrandsTodoApi.Repositories
{
    public interface ITodoRepository
    {
        IEnumerable<TodoItem> GetAll();
        TodoItem Find(string key);
        void Add(TodoItem item);
        void Remove(TodoItem item);
        void Update(TodoItem item);
        void Save();
    }

}
