using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrandsTodoApi.Models;

namespace ErrandsTodoApi.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoItem>> GetAll();
        Task<TodoItem> FindAsync(string key);
        void AddAsync(TodoItem item);
        void RemoveAsync(TodoItem item);
        void UpdateAsync(TodoItem item);
    }

}
