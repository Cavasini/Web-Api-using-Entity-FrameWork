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
        private readonly ITimeTrackerInterface _TimeTrackerInterface;
        [HttpGet]
        public async Task<ServiceResponse<List<TimeTracker>>> GetTimeTrackers()
        {
            return Ok(await _TimeTrackerInterface);
        }
    }
}
