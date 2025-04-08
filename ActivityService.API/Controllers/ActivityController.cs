using ActivityService.Core.DTO;
using ActivityService.Core.Services.SeparateService;
using Microsoft.AspNetCore.Mvc;


namespace PayrollService.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _activityService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _activityService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(ActivityDTO dto)
        {
            var result = await _activityService.UpsertAsync(dto, s => s.ActivityId == dto.ActivityId);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _activityService.DeleteAsync(id);
            return NoContent();
        }
    }
}
