using Microsoft.AspNetCore.Mvc;
using PayrollService.Core.Domain.Entities;
using PayrollService.Core.DTO;
using PayrollService.Core.Services.CommonServiceContract;
using PayrollService.Core.Services.SeparateService;

namespace PayrollService.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SalaryHistController : ControllerBase
    {
        private readonly ISalaryHistService _salaryHistService;

        public SalaryHistController(ISalaryHistService salaryHistService)
        {
            _salaryHistService = salaryHistService;
        }


        // Lấy tất cả SalaryBase dưới dạng DTO
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _salaryHistService.GetAllAsync();
            return Ok(result);
        }

        // Lấy SalaryBase theo ID dưới dạng DTO
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _salaryHistService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // Thêm hoặc cập nhật SalaryBase
        [HttpPost]
        public async Task<IActionResult> Upsert(SalaryHistDTO dto)
        {
            var result = await _salaryHistService.UpsertAsync(dto, s => s.HistId == dto.HistId);
            return Ok(result);
        }

        // Xóa SalaryBase
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _salaryHistService.DeleteAsync(id);
            return NoContent();
        }
    }
}
