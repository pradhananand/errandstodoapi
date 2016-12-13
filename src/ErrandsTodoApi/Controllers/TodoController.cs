using System.Collections.Generic;
using System.Threading.Tasks;
using ErrandsTodoApi.Filters;
using ErrandsTodoApi.Models;
using ErrandsTodoApi.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ErrandsTodoApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ServiceFilter(typeof(ApiExceptionFilterAttribute))]
    public class TodoController : Controller
    {
        public ITodoRepository todoRepository { get; set; }

        public TodoController(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        // GET: api/todos
        [HttpGet]
        public async Task<IEnumerable<TodoItem>> Get()
        {
            return await todoRepository.GetAll();
        }

        // GET api/todo/5
        [HttpGet("{id}", Name = "GetTodo")]
        public async Task<IActionResult> GetById(string id)
        {
            var item = await todoRepository.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TodoItem todoItem)
        {
            if (todoItem == null)
            {
                return BadRequest();
            }
            var todo = await todoRepository.FindAsync(todoItem.Key);
            if(todo == null)

            {
                todoRepository.AddAsync(todoItem);
                return new ObjectResult(todoItem);
            }
            else
            {
                todo.Name = todoItem.Name;
                todo.IsComplete = todoItem.IsComplete;
                return new ObjectResult(todo);
            }
        }


        // DELETE api/todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var todo = await todoRepository.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            todoRepository.RemoveAsync(todo);
            return new NoContentResult();
        }
    }
}
