using AutoMapper;
using Look.DataContext;
using Look.Dtos;
using Look.Model;
using Microsoft.AspNetCore.Mvc;

namespace Look.Service.ProjectService
{
    public class ProjectService : IProjectInterface
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public ProjectService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<Project>>> CreateProject(CreateProjectDto projectDto)
        {
            ServiceResponse<List<Project>> serviceResponse = new ServiceResponse<List<Project>>();
            try
            {
                Project newProject = _mapper.Map<Project>(projectDto);
                _context.Projects.Add(newProject);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Projects.ToList();
                serviceResponse.Sucesso = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<Project>>> DeleteProject(Guid id)
        {
            ServiceResponse<List<Project>> serviceResponse = new ServiceResponse<List<Project>>();
            try
            {
                Project project = _context.Projects.SingleOrDefault(x => x.Id == id);
                if (project != null)
                {
                    _context.Projects.Remove(project);
                    await _context.SaveChangesAsync();
                    serviceResponse.Dados = _context.Projects.ToList();
                    serviceResponse.Mensagem = "Projeto Deletado";
                    serviceResponse.Sucesso = true;
                }
                else
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Projeto não encontrado!";
                    serviceResponse.Sucesso = false;
                }
            } catch (Exception ex)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Project>>> GetProjects()
        {
            ServiceResponse<List<Project>> serviceResponse = new ServiceResponse<List<Project>>();
            try
            {
                serviceResponse.Dados = _context.Projects.ToList();
                serviceResponse.Sucesso = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Project>>> UpdateProject(UpdateProjectDto projectDto)
        {
            ServiceResponse<List<Project>> serviceResponse = new ServiceResponse<List<Project>>();

            try
            {
                Project project = _context.Projects.SingleOrDefault(x => x.Id == projectDto.Id);

                if (project != null)
                {
                    project.Name = projectDto.Name;
                    project.UpdatedAt = DateTime.UtcNow;
                    _context.Projects.Update(project);
                    await _context.SaveChangesAsync();
                    serviceResponse.Dados = _context.Projects.ToList();
                    serviceResponse.Mensagem = "Projeto Atualizado";
                    serviceResponse.Sucesso = true;
                }
                else
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Projeto não encontrado!";
                    serviceResponse.Sucesso = false;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

    }
}
