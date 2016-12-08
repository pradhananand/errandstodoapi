using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrandsTodoApi.Models;

namespace ErrandsTodoApi.Repositories
{
    public interface ITodoRepository
    {
        void Add(TodoItem item);
        IEnumerable<TodoItem> GetAll();
        TodoItem Find(string key);
        TodoItem Remove(string key);
        void Update(TodoItem item);
    }

}
