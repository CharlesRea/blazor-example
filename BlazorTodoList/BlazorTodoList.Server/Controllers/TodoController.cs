using BlazorTodoList.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorTodoList.Server.Controllers
{
    [Route("api/todo")]
    public class TodoController : Controller
    {
        private readonly DataContext dataContext;

        public TodoController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet, Route("")]
        public async Task<IList<TodoItem>> GetTodoItems()
        {
            return await dataContext.TodoItems.ToListAsync();
        }

        [HttpPost, Route("")]
        public async Task<TodoItem> CreateTodoItem([FromBody]TodoItem todo)
        {
            dataContext.TodoItems.Add(todo);
            await dataContext.SaveChangesAsync();
            return todo;
        }
        
        [HttpPost, Route("{id}/complete")]
        public async Task<TodoItem> CompleteTodo(long id)
        {
            var todo = await dataContext.TodoItems.FindAsync(id);
            todo.IsDone = true;
            await dataContext.SaveChangesAsync();
            return todo;
        }
    }
}
