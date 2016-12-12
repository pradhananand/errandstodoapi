using System;
using System.Collections.Generic;
using ErrandsTodoApi.Models;
using ErrandsTodoApi.DAL;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ErrandsTodoApi.Repositories
{
    public class TodoRepository : ITodoRepository
    {

        private readonly ErrandsDbContext context;

        public TodoRepository(ErrandsDbContext context)
        {
            this.context = context;
        }

        public async void AddAsync(TodoItem item)
        {
            context.TodoItems.Add(item);
            await SaveAsync();
        }

        public async Task<TodoItem> FindAsync(string key)
        {
            return await context.TodoItems.SingleOrDefaultAsync(s => s.Key == key); 
        }

        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            return await context.TodoItems.ToListAsync();
        }

        public async void RemoveAsync(TodoItem todoItem)
        { 
            context.TodoItems.Remove(todoItem);
            await SaveAsync();
        }

        public async void UpdateAsync(TodoItem item)
        {
            context.Entry(item).State = EntityState.Modified;
            await SaveAsync();
        }

        private async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }

}
