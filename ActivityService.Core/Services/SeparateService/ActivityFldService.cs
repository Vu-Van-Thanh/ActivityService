using ActivityService.Core.Domain.Entities;
using ActivityService.Core.DTO;
using ActivityService.Core.RepositoryContracts;
using ActivityService.Core.Services.CommonServiceContract;
using AutoMapper;


namespace ActivityService.Core.Services.SeparateService
{
    public interface IActivityFldService : IService<ActivityFld, ActivityFldDTO>
    {
        
    }
    public class ActivityFldService : Service<ActivityFld, ActivityFldDTO>, IActivityFldService
    {
        public ActivityFldService(IRepository<ActivityFld> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
