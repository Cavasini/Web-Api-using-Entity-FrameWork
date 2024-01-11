using Look.Dtos;
using Look.Model;

namespace Look.Service.TimeTrackersService
{
    public interface ITimeTrackerInterface
    {
        Task<ServiceResponse<List<TimeTracker>>> GetTimeTrackers();
        Task<ServiceResponse<List<TimeTracker>>> CreateTimeTracker(CreateTimeTrackerDto timeTrackerDto);

    }
}
