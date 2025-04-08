using ActivityService.Core.DTO;
using ActivityService.Core.Services.SeparateService;
using Microsoft.AspNetCore.Mvc;

namespace PayrollService.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActivityRequestController : ControllerBase
    {
        private readonly IActivityRequestService _activityRequestService;

        public ActivityRequestController(IActivityRequestService activityRequestService)
        {
            _activityRequestService = activityRequestService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _activityRequestService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _activityRequestService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(ActivityRequestDTO dto)
        {
            var result = await _activityRequestService.UpsertAsync(dto, s => s.RequestId == dto.RequestId);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _activityRequestService.DeleteAsync(id);
            return NoContent();
        }
    }
}
