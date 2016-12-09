//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using ErrandsTodoApi.Models;

//namespace ErrandsTodoApi.DAL
//{
//    public class ErrandsDbInitializer : DropCreateDatabaseIfModelChanges<ErrandsDbContext>
//    {
//        protected override void Seed(ErrandsDbContext context)
//        {
//            var todoItems = new List<TodoItem>
//            {
//                new TodoItem { Key = "1", Name = "Costco Milk", IsComplete = false },
//                new TodoItem { Key = "2", Name = "Costco Milk", IsComplete = false },
//                new TodoItem { Key = "3", Name = "Costco Milk", IsComplete = false },
//            };

//            context.TodoItems.AddRange(todoItems);

//            context.SaveChanges();
//        }
//    }
//}
