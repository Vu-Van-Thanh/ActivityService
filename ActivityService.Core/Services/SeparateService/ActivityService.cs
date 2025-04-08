using ActivityService.Core.Domain.Entities;
using ActivityService.Core.DTO;
using ActivityService.Core.RepositoryContracts;
using ActivityService.Core.Services.CommonServiceContract;
using AutoMapper;
namespace ActivityService.Core.Services.SeparateService
{
    public interface IActivityService : IService<Activity, ActivityDTO>
    {

    }
    public class ActivitiesService : Service<Activity, ActivityDTO>, IActivityService
    {
        public ActivitiesService(IRepository<Activity> repository, IMapper mapper)
            : base(repository, mapper)
        {

        }

    }
}
