using System.Data.Entity;
using ErrandsTodoApi.Models;


namespace ErrandsTodoApi.DAL
{
    [DbConfigurationType(typeof(DbConfig))]
    public class ErrandsDbContext : DbContext
    {
        //static ErrandsDbContext()
        //{
        //    //Database.SetInitializer(new ErrandsDbInitializer());
        //}

        public ErrandsDbContext(string connectionName) :
            base(connectionName) { }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
