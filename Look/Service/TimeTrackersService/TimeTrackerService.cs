using AutoMapper;
using Look.DataContext;
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

        public Task<ServiceResponse<TimeTracker>> CreateTimeTracker()
        {
            throw new NotImplementedException();
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
