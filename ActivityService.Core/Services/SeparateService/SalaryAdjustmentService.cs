using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PayrollService.Core.Domain.Entities;
using PayrollService.Core.DTO;
using PayrollService.Core.RepositoryContracts;
using PayrollService.Core.Services.CommonServiceContract;

namespace PayrollService.Core.Services.SeparateService
{
    public interface ISalaryAdjustmentService : IService<Activity, ActivityDTO>
    {

    }
    public class SalaryAdjustmentService : Service<Activity, ActivityDTO>, ISalaryAdjustmentService
    {
        public SalaryAdjustmentService(IRepository<Activity> repository, IMapper mapper)
            : base(repository, mapper)
        {

        }

    }
}
