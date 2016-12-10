using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrandsTodoApi.DAL;
using ErrandsTodoApi.Models;
using ErrandsTodoApi.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ErrandsTodoApi.Controllers
{
    [Route("api/[controller]")]
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


        // PUT api/todo/5
        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            todoRepository.Add(item);
            todoRepository.Save();
            return CreatedAtRoute("GetTodo", new { id = item.Key }, item);
        }


        [HttpPut("{id}")]
        public IActionResult Update(string key)
        {
            var todo = todoRepository.Find(key);
            if (todo == null)
            {
                return NotFound();
            }

            todoRepository.Update(todo);
            todoRepository.Save();
            return new NoContentResult();
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
            todoRepository.Save();
            return new NoContentResult();
        }
    }
}
