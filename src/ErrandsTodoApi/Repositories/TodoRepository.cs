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

        public void Add(TodoItem item)
        {
            context.TodoItems.Add(item);
            Save();
        }

        public TodoItem Find(string key)
        {
            return context.TodoItems.SingleOrDefault(s => s.Key == key); 
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return context.TodoItems.ToList();
        }

        public void Remove(TodoItem todoItem)
        { 
            context.TodoItems.Remove(todoItem);
            Save();
        }

        public void Update(TodoItem item)
        {
            context.Entry(item).State = EntityState.Modified;
            Save();
        }

        private void Save()
        {
            context.SaveChanges();
        }
    }

}
