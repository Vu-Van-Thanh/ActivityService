
using ActivityService.API.Repositories;
using ActivityService.Core.Domain.Entities;
using ActivityService.Core.RepositoryContracts.SeparateRepository;
using ActivityService.Infrastructure.AppDbContext;

namespace ActivityService.Infrastructure.Repositories
{
    public class ActivityFldRepository : Repository<ActivityFld>, IActivityFldRepository
    {
        public ActivityFldRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
