using Look.Dtos;
using Look.Model;
using Microsoft.AspNetCore.Mvc;

namespace Look.Service.ProjectService
{
    public interface IProjectInterface
    {
        Task<ServiceResponse<List<Project>>> GetProjects();
        Task<ServiceResponse<List<Project>>> CreateProject(CreateProjectDto projectDto);
        Task<ServiceResponse<List<Project>>> DeleteProject(Guid id);
        Task<ServiceResponse<List<Project>>> UpdateProject(UpdateProjectDto projectDto);
    }
}
