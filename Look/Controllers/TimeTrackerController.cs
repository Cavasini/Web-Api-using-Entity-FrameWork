using Look.Dtos;
using Look.Model;
using Look.Service.TimeTrackersService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Look.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeTrackerController : ControllerBase
    {
        private readonly ITimeTrackerInterface _timeTrackerInterface;

        public TimeTrackerController(ITimeTrackerInterface timeTrackerInterface)
        {
            _timeTrackerInterface = timeTrackerInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<TimeTracker>>>> GetTimeTrackers()
        {
            return Ok(await _timeTrackerInterface.GetTimeTrackers());
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<IEnumerable<TimeTracker>>>> CreateTimeTracker([FromBody] CreateTimeTrackerDto timeTrackerDto)
        {
            return Ok(await _timeTrackerInterface.CreateTimeTracker(timeTrackerDto));
        }
    }
}
