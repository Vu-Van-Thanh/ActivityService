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
    public interface ISalaryBaseService : IService<Domain.Entities.ActivityFld, DTO.ActivityFld>
    {
        
    }
    public class SalaryBaseService : Service<Domain.Entities.ActivityFld, DTO.ActivityFld>, ISalaryBaseService
    {
        public SalaryBaseService(IRepository<Domain.Entities.ActivityFld> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
