using Look.Model;

namespace Look.Service.ProjectService
{
    public interface IProjectInterface
    {
        Task<ServiceResponse<List<Project>>> GetProjects();
        Task<ServiceResponse<List<Project>>> CreateProject(string name);
        Task<ServiceResponse<List<Project>>> DeleteProject(Guid id);
        Task<ServiceResponse<List<Project>>> UpdateProject(Guid id, string name);
    }
}
