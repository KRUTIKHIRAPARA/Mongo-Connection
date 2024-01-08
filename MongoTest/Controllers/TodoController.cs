using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoTest.Models;

namespace MongoTest.Controllers
{
    [Route("Todo")]
    public class TodoController : Controller
    {
        private readonly MongoDbContext _context;

        public TodoController(MongoDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public ActionResult<List<Todo>> GetData()
        {
            return _context.TodoItems.Find(item => true).ToList();
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> AddData(Todo todo)
        {
            await _context.TodoItems.InsertOneAsync(todo);
            return Ok(todo);
        }

    }
}
