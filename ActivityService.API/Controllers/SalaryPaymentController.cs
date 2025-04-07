using Microsoft.AspNetCore.Mvc;
using PayrollService.Core.Domain.Entities;
using PayrollService.Core.Domain.VnPay;
using PayrollService.Core.DTO;
using PayrollService.Core.Services.CommonServiceContract;
using PayrollService.Core.Services.PaymentService;
using PayrollService.Core.Services.SeparateService;

namespace PayrollService.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SalaryPaymentController : ControllerBase
    {
        private readonly ISalaryPaymentService _salaryPaymentService;
        private readonly IVnPayService _vnPayService;

        public SalaryPaymentController(ISalaryPaymentService salaryPaymentService, IVnPayService vnPayService)
        {
            _salaryPaymentService = salaryPaymentService;
            _vnPayService = vnPayService;
        }


        // Lấy tất cả SalaryPayment dưới dạng DTO
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _salaryPaymentService.GetAllAsync();
            return Ok(result);
        }

        // Lấy SalaryPayment theo ID dưới dạng DTO
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _salaryPaymentService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // Thêm hoặc cập nhật SalaryPayment
        [HttpPost]
        public async Task<IActionResult> Upsert(SalaryPaymentDTO dto)
        {
            var result = await _salaryPaymentService.UpsertAsync(dto, s => s.PaymentId == dto.PaymentId);
            return Ok(result);
        }

        // Xóa SalaryPayment
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _salaryPaymentService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("PaymentUrl")]
        public IActionResult CreatePaymentUrlVnpay(PaymentInformationModel model)
        {
            var url = _vnPayService.CreatePaymentUrl(model, HttpContext);

            return Redirect(url);
        }


        /// <summary>
        /// endpoint trả về khi thanh toán thành công
        /// </summary>
        /// <returns></returns>
        [HttpGet("PaymentCallback")]
        public IActionResult PaymentCallbackVnpay()
        {
            var response = _vnPayService.PaymentExecute(HttpContext.Request.Query);

            return Ok(response);
        }

        [HttpPost("BatchPaymentUrl")]
        public async Task<IActionResult> CreateBatchPaymentUrlVnpay(BatchPaymentModel batchModel)
        {
            var batchStatus = await _vnPayService.CreateBatchPaymentUrls(batchModel, HttpContext);
            return Ok(new { 
                BatchId = batchStatus.BatchId,
                Description = batchStatus.Description,
                Status = batchStatus.Status,
                Payments = batchStatus.Payments.Select(p => new {
                    p.PaymentId,
                    p.Name,
                    p.Amount,
                    p.Status,
                    p.PaymentUrl
                })
            });
        }

        [HttpGet("BatchPaymentStatus/{batchId}")]
        public IActionResult GetBatchPaymentStatus(string batchId)
        {
            var status = _vnPayService.GetBatchPaymentStatus(batchId);
            if (status == null)
            {
                return NotFound();
            }
            return Ok(status);
        }

        [HttpGet("BatchPaymentCallback")]
        public async Task<IActionResult> BatchPaymentCallbackVnpay()
        {
            var responses = await _vnPayService.ProcessBatchPaymentCallbacks(HttpContext.Request.Query);
            return Ok(responses);
        }
    }
}
