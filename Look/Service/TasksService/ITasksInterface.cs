using Look.Model;

namespace Look.Service.TasksService
{
    public interface ITasksInterface
    {
        Task<ServiceResponse<List<Tasks>>> GetTasks();
        Task<ServiceResponse<List<Tasks>>> CreateTask(string name, string description, Guid projectId);
        Task<ServiceResponse<List<Tasks>>> DeleteTask(Guid id);
    }
}
