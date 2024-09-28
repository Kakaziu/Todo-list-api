using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.Repositories;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly TaskRepository _taskRepository;

        public TaskController(TaskRepository taskRepository) 
        { 
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> Index()
        {
            var tasks = await _taskRepository.Index();

            return Ok(tasks);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> Show(int id)
        {
            var task = _taskRepository.Show(id);

            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> Create([FromBody] TaskModel task) 
        {
            var newTask = await _taskRepository.Create(task);

            return Ok(newTask);
        }

        [HttpPut("{id}")] 
        public async Task<ActionResult<TaskModel>> Update([FromBody] TaskModel task, int id)
        {
            task.Id = id;
            var updatedTask = await _taskRepository.Update(task, id);

            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool isDeleted = await _taskRepository.Delete(id);

            return isDeleted;
        }
    }
}
