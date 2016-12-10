using ErrandsTodoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ErrandsTodoApi.DAL
{
    public class ErrandsDbContext : DbContext
    {
        public ErrandsDbContext(DbContextOptions<ErrandsDbContext> options) : base(options)
        {
        }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
