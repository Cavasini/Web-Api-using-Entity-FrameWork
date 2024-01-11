using Look.Dtos;
using Look.Model;

namespace Look.Service.TasksService
{
    public interface ITasksInterface
    {
        Task<ServiceResponse<List<Tasks>>> GetTasks();
        Task<ServiceResponse<List<Tasks>>> CreateTask(CreateTaskDto taskDto);
        Task<ServiceResponse<List<Tasks>>> DeleteTask(Guid id);
    }
}
