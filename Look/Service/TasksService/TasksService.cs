using AutoMapper;
using Look.DataContext;
using Look.Dtos;
using Look.Model;

namespace Look.Service.TasksService
{
    public class TasksService : ITasksInterface
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public TasksService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<Tasks>>> CreateTask(CreateTaskDto taskDto)
        {
            ServiceResponse<List<Tasks>> serviceResponse = new ServiceResponse<List<Tasks>>();

            try
            {   
                Project project = _context.Projects.SingleOrDefault(x => x.Id == taskDto.ProjectId);
                if (project != null)
                {
                    Tasks newTask = _mapper.Map<Tasks>(taskDto);
                    _context.Tasks.Add(newTask);
                    await _context.SaveChangesAsync();
                    serviceResponse.Dados = _context.Tasks.ToList();
                    serviceResponse.Mensagem = "Nova task criada!";
                    serviceResponse.Sucesso = true;
                }
                else
                {
                    serviceResponse.Mensagem = "Esse Projeto não existe";
                    serviceResponse.Sucesso = false;
                }
            }catch(Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Tasks>>> DeleteTask(Guid id)
        {
            ServiceResponse<List<Tasks>> serviceResponse = new ServiceResponse<List<Tasks>>();

            try{
                Tasks taskForDelete = _context.Tasks.SingleOrDefault(x => x.Id == id);
                _context.Tasks.Remove(taskForDelete);
                await _context.SaveChangesAsync();
                serviceResponse.Mensagem = "Task deletada!";
                serviceResponse.Sucesso = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = ex.Message;
            }
            return serviceResponse;


        }

        public async Task<ServiceResponse<List<Tasks>>> GetTasks()
        {
            ServiceResponse<List<Tasks>> serviceResponse = new ServiceResponse<List<Tasks>>();

            try
            {
                serviceResponse.Dados = _context.Tasks.ToList();
                serviceResponse.Sucesso = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = ex.Message;
            }
            return serviceResponse;
        }
    }
}
