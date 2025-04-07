using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepartmentService.API.Repositories;
using PayrollService.Core.Domain.Entities;
using PayrollService.Core.RepositoryContracts.SeparateRepository;
using PayrollService.Infrastructure.AppDbContext;

namespace PayrollService.Infrastructure.Repositories
{
    public class SalaryAdjustmentRepository : Repository<SalaryAdjustment>, ISalaryAdjustmentRepository
    {
        public SalaryAdjustmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
