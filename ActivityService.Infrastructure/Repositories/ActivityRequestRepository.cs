
using ActivityService.API.Repositories;
using ActivityService.Core.Domain.Entities;
using ActivityService.Core.RepositoryContracts.SeparateRepository;
using ActivityService.Infrastructure.AppDbContext;


namespace ActivityService.Infrastructure.Repositories
{
    public class ActivityRequestRepository : Repository<ActivityRequest>, IActivityRequestRepository
    {
        public ActivityRequestRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

}
