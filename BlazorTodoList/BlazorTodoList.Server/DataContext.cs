using Microsoft.EntityFrameworkCore;
using BlazorTodoList.Shared;

namespace BlazorTodoList.Server
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
