using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using PayrollService.Core.Domain.Entities;
using PayrollService.Core.DTO;
using PayrollService.Core.RepositoryContracts;
using PayrollService.Core.Services.CommonServiceContract;

namespace PayrollService.Core.Services.SeparateService
{
    public interface ISalaryPaymentService : IService<Domain.Entities.Attendance, DTO.AttendanceDTO>
    {
        
    }

    public class SalaryPaymentService : Service<Domain.Entities.Attendance, DTO.AttendanceDTO>, ISalaryPaymentService
    {

        public SalaryPaymentService(IRepository<Domain.Entities.Attendance> repository, IMapper mapper) : base(repository, mapper)
        {
        }
       
    }
}
