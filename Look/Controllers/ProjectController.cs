using Look.Dtos;
using Look.Model;
using Look.Service.ProjectService;
using Look.Service.UsersService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Look.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectInterface _projectInterface;

        public ProjectController(IProjectInterface projectInterface)
        {
            _projectInterface = projectInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IAsyncEnumerable<Project>>>> GetProjects()
        {
            return Ok(await _projectInterface.GetProjects());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<IAsyncEnumerable<Project>>>> CreateProject([FromBody] CreateProjectDto projectDto)
        {
            return Ok(await _projectInterface.CreateProject(projectDto));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<IAsyncEnumerable<Project>>>> DeleteProject(Guid id)
        {
            return Ok(await _projectInterface.DeleteProject(id));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<IAsyncEnumerable<Project>>>> UpdadteProject([FromBody] UpdateProjectDto projectDto)
        {
            return Ok(await _projectInterface.UpdateProject(projectDto));

        }

    }
}
