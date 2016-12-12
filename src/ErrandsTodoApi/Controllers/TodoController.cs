using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrandsTodoApi.DAL;
using ErrandsTodoApi.Filters;
using ErrandsTodoApi.Models;
using ErrandsTodoApi.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ErrandsTodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiExceptionFilterAttribute]
    public class TodoController : Controller
    {
        public ITodoRepository todoRepository { get; set; }

        public TodoController(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        // GET: api/todos
        [HttpGet]
        public IEnumerable<TodoItem> Get()
        {
            return todoRepository.GetAll();
        }

        // GET api/todo/5
        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
            var item = todoRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }


        [HttpPost]
        public IActionResult Post([FromBody]TodoItem todoItem)
        {
            if (todoItem == null)
            {
                return BadRequest();
            }
            var todo = todoRepository.Find(todoItem.Key);
            if(todo == null)

            {
                todoRepository.Add(todoItem);
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
        public IActionResult Delete(string id)
        {
            var todo = todoRepository.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todoRepository.Remove(todo);
            return new NoContentResult();
        }
    }
}
