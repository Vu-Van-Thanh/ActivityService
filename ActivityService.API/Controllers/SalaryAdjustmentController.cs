using Microsoft.AspNetCore.Mvc;
using PayrollService.Core.Domain.Entities;
using PayrollService.Core.DTO;
using PayrollService.Core.Services.CommonServiceContract;
using PayrollService.Core.Services.SeparateService;

namespace PayrollService.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SalaryAdjustmentController : ControllerBase
    {
        private readonly ISalaryAdjustmentService _salaryAdjustmentService;

        public SalaryAdjustmentController(ISalaryAdjustmentService salaryAdjustmentService)
        {
            _salaryAdjustmentService = salaryAdjustmentService;
        }


        // Lấy tất cả SalaryBase dưới dạng DTO
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _salaryAdjustmentService.GetAllAsync();
            return Ok(result);
        }

        // Lấy SalaryBase theo ID dưới dạng DTO
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _salaryAdjustmentService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // Thêm hoặc cập nhật SalaryBase
        [HttpPost]
        public async Task<IActionResult> Upsert(SalaryAdjustmentDTO dto)
        {
            var result = await _salaryAdjustmentService.UpsertAsync(dto, s => s.AdjustmentId == dto.AdjustmentId);
            return Ok(result);
        }

        // Xóa SalaryBase
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _salaryAdjustmentService.DeleteAsync(id);
            return NoContent();
        }
    }
}
