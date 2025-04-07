using Microsoft.AspNetCore.Mvc;
using PayrollService.Core.Domain.Entities;
using PayrollService.Core.DTO;
using PayrollService.Core.Services.CommonServiceContract;
using PayrollService.Core.Services.SeparateService;

namespace PayrollService.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SalaryBaseController : ControllerBase
    {
        private readonly ISalaryBaseService _salaryBaseService;

        public SalaryBaseController(ISalaryBaseService salaryBaseService)
        {
            _salaryBaseService = salaryBaseService;
        }


        // Lấy tất cả SalaryBase dưới dạng DTO
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _salaryBaseService.GetAllAsync();
            return Ok(result);
        }

        // Lấy SalaryBase theo ID dưới dạng DTO
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _salaryBaseService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // Thêm hoặc cập nhật SalaryBase
        [HttpPost]
        public async Task<IActionResult> Upsert(SalaryBaseDTO dto)
        {
            var result = await _salaryBaseService.UpsertAsync(dto, s => s.SalaryId == dto.SalaryId);
            return Ok(result);
        }

        // Xóa SalaryBase
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _salaryBaseService.DeleteAsync(id);
            return NoContent();
        }
    }
}
