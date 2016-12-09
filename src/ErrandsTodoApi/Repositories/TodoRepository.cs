using System;
using System.Collections.Generic;
using ErrandsTodoApi.Models;
using ErrandsTodoApi.DAL;
using System.Linq;
using System.Data.Entity;

namespace ErrandsTodoApi.Repositories
{
    public class TodoRepository : ITodoRepository, IDisposable
    {

        private readonly ErrandsDbContext context;

        public TodoRepository(ErrandsDbContext context)
        {
            this.context = context;
        }

        public void Add(TodoItem item)
        {
            context.TodoItems.Add(item);
        }

        public TodoItem Find(string key)
        {
            return context.TodoItems.Find(key);
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return context.TodoItems.ToList();
        }

        public void Remove(string key)
        {
            TodoItem todoItem = context.TodoItems.Find(key);
            context.TodoItems.Remove(todoItem);
        }

        public void Update(TodoItem item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
