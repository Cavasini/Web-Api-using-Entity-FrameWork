using AutoMapper;
using Look.DataContext;
using Look.Dtos;
using Look.Model;

namespace Look.Service.TimeTrackersService
{
    public class TimeTrackerService : ITimeTrackerInterface
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public TimeTrackerService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<TimeTracker>>> CreateTimeTracker(CreateTimeTrackerDto timeTrackerDto)
        {
            ServiceResponse<List<TimeTracker>> serviceResponse = new ServiceResponse<List<TimeTracker>>();


            try
            {
                Tasks task = _context.Tasks.SingleOrDefault(x => x.Id == timeTrackerDto.TaskId);
                Users user = _context.Users.SingleOrDefault(x => x.Id == timeTrackerDto.CollaboratorId);
                if (task != null)
                {
                    if (user != null)
                    {
                        TimeTracker newTimeTracker = _mapper.Map<TimeTracker>(timeTrackerDto);
                        _context.Add(newTimeTracker);
                        await _context.SaveChangesAsync();
                        serviceResponse.Dados = _context.TimeTrackers.ToList();
                        serviceResponse.Mensagem = "Time Tracker criado";
                        serviceResponse.Sucesso = true;
                    }
                    else
                    {
                        serviceResponse.Mensagem = "CollaboratorId inválido";
                        serviceResponse.Sucesso = false;
                    }
                }
                else
                {
                    serviceResponse.Mensagem = "TaskId inválido";
                    serviceResponse.Sucesso = false;
                }

            }catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TimeTracker>>> GetTimeTrackers()
        {

            ServiceResponse<List<TimeTracker>> serviceResponse = new ServiceResponse<List<TimeTracker>>();

            try
            {
                serviceResponse.Dados = _context.TimeTrackers.ToList();
                serviceResponse.Mensagem = null;
                serviceResponse.Sucesso = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Dados = null;
            }
            return serviceResponse;
        }
    }
}
