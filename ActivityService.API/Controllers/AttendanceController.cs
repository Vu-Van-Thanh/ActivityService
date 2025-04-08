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


        // Lấy tất cả SalaryPayment dưới dạng DTO
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _attendanceService.GetAllAsync();
            return Ok(result);
        }

        // Lấy SalaryPayment theo ID dưới dạng DTO
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

        // Thêm hoặc cập nhật SalaryPayment
        [HttpPost]
        public async Task<IActionResult> Upsert(AttendanceDTO dto)
        {
            var result = await _attendanceService.UpsertAsync(dto, s => s.AttendanceId == dto.AttendanceId);
            return Ok(result);
        }

        // Xóa SalaryPayment
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _attendanceService.DeleteAsync(id);
            return NoContent();
        }

      
    }
}
