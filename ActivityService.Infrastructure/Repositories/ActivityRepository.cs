using ActivityService.API.Repositories;
using ActivityService.Core.Domain.Entities;
using ActivityService.Core.RepositoryContracts.SeparateRepository;
using ActivityService.Infrastructure.AppDbContext;


namespace ActivityService.Infrastructure.Repositories
{
    public class ActivityRepository : Repository<Activity>, IActivityRepository
    {
        public ActivityRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
