using Look.Model;
using Look.Service.ProjectService;
using Look.Service.TasksService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Look.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksInterface _tasksInterface;

        public TasksController(ITasksInterface tasksInterface)
        {
            _tasksInterface = tasksInterface;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IAsyncEnumerable<Tasks>>>> GetTasks()
        {
            return Ok(await _tasksInterface.GetTasks());
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<IAsyncEnumerable<Tasks>>>> CreateTask(string name, string description, Guid projectId)
        {
            return Ok(await _tasksInterface.CreateTask(name, description, projectId));
        }
    }
}
