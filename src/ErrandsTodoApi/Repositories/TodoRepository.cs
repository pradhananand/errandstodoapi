using System;
using System.Collections.Generic;
using ErrandsTodoApi.Models;
using ErrandsTodoApi.DAL;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ErrandsTodoApi.Repositories
{
    public class TodoRepository : ITodoRepository
    {

        private readonly ErrandsDbContext context;

        public TodoRepository(ErrandsDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(TodoItem item)
        {
            item.Key = Guid.NewGuid().ToString();
            context.TodoItems.Add(item);
            await SaveAsync();
        }

        public async Task<TodoItem> FindAsync(string key)
        {
            return await context.TodoItems.AsNoTracking().SingleOrDefaultAsync(s => s.Key == key); 
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            return await context.TodoItems.AsNoTracking().ToListAsync();
        }

        public async Task RemoveAsync(TodoItem todoItem)
        { 
            context.TodoItems.Remove(todoItem);
            await SaveAsync();
        }

        public async Task UpdateAsync(TodoItem item)
        {
            var _item = await FindAsync(item.Key);
            if (_item != null)
            {
                context.Entry(item).State = EntityState.Modified;
            }
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }


        #region Searching
        public async Task<int> CountAsync()
        {
            return await context.Set<TodoItem>().CountAsync();
        }

        public async Task<TodoItem> FindAsync(Expression<Func<TodoItem, bool>> match)
        {
            return await context.Set<TodoItem>().SingleOrDefaultAsync(match);
        }

        public async Task<ICollection<TodoItem>> FindAllAsync(Expression<Func<TodoItem, bool>> match)
        {
            return await context.Set<TodoItem>().Where(match).ToListAsync();
        }
        #endregion
    }

}
