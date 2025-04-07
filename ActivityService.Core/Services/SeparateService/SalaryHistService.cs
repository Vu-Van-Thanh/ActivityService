using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PayrollService.Core.Domain.Entities;
using PayrollService.Core.DTO;
using PayrollService.Core.RepositoryContracts;
using PayrollService.Core.Services.CommonServiceContract;

namespace PayrollService.Core.Services.SeparateService
{
    public interface ISalaryHistService : IService<ActivityRequest, ActivityRequest>
    {
       
    }
    public class SalaryHistService : Service<ActivityRequest, ActivityRequest>, ISalaryHistService
    {
        public SalaryHistService(IRepository<ActivityRequest> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }

}
