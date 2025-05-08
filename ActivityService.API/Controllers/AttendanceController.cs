using ActivityService.Core.DTO;
using ActivityService.Core.Services.SeparateService;
using Microsoft.AspNetCore.Mvc;


namespace PayrollService.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _attendanceService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("filter-attendance")]
        public async Task<IActionResult> GetAll([FromQuery] AttendaceFilterDTO filter)
        {
            var result = await _attendanceService.GetAttendaceByFilter(filter.ToExpression());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _attendanceService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(AttendanceDTO dto)
        {
            var result = await _attendanceService.UpsertAsync(dto, s => s.AttendanceId == dto.AttendanceId);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _attendanceService.DeleteAsync(id);
            return NoContent();
        }

      
    }
}
