using ActivityService.Core.DTO;
using ActivityService.Core.Services.SeparateService;
using Microsoft.AspNetCore.Mvc;


namespace PayrollService.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActivityFldController : ControllerBase
    {
        private readonly IActivityFldService _activityFldService;

        public ActivityFldController(IActivityFldService activityFldService)
        {
            _activityFldService = activityFldService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _activityFldService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _activityFldService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("/activities/fields")]
        public async Task<IActionResult> GetFieldsByActivityId(Guid activityId)
        {
            var result = await _activityFldService.FindAsync(s => s.ActivityId == activityId);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Upsert(ActivityFldDTO dto)
        {
            var result = await _activityFldService.UpsertAsync(dto, s => s.FieldId == dto.FieldId);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _activityFldService.DeleteAsync(id);
            return NoContent();
        }
    }
}
