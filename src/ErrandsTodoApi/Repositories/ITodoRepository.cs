using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrandsTodoApi.Models;

namespace ErrandsTodoApi.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task<TodoItem> FindAsync(string key);
        Task AddAsync(TodoItem item);
        Task RemoveAsync(TodoItem item);
        Task UpdateAsync(TodoItem item);
        Task SaveAsync();
    }

}
