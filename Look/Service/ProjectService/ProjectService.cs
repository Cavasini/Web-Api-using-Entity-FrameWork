using Look.DataContext;
using Look.Model;

namespace Look.Service.ProjectService
{
    public class ProjectService : IProjectInterface
    {
        private readonly ApplicationDbContext _context;

        public ProjectService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Project>>> CreateProject(string name)
        {
            ServiceResponse<List<Project>> serviceResponse = new ServiceResponse<List<Project>>();
            try
            {
                Project project = new Project() { Name = name };
                _context.Projects.Add(project);
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

        public async Task<ServiceResponse<List<Project>>> UpdateProject(Guid id, string name)
        {
            ServiceResponse<List<Project>> serviceResponse = new ServiceResponse<List<Project>>();

            try
            {
                Project project = _context.Projects.SingleOrDefault(x => x.Id == id);

                if (project != null)
                {
                    project.Name = name;
                    project.UpdatedAt = DateTime.UtcNow;
                    _context.Projects.Update(project);
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
