using System.Linq.Expressions;
using ActivityService.Core.Domain.Entities;
using ActivityService.Core.DTO;
using ActivityService.Core.RepositoryContracts;
using ActivityService.Core.RepositoryContracts.SeparateRepository;
using ActivityService.Core.Services.CommonServiceContract;
using AutoMapper;


namespace ActivityService.Core.Services.SeparateService
{
    public interface IActivityRequestService : IService<ActivityRequest, ActivityRequestDTO>
    {
       Task<List<ActivityRequestDTO>> GetByFilterAsync(ActivityFilter filter);
    }
    public class ActivityRequestService : Service<ActivityRequest, ActivityRequestDTO>, IActivityRequestService
    {
        private readonly IActivityRequestRepository _activityRequestRepository;
        public ActivityRequestService(IRepository<ActivityRequest> repository, IMapper mapper, IActivityRequestRepository activityRequest) : base(repository, mapper)
        {
            _activityRequestRepository = activityRequest;
        }

        public async Task<List<ActivityRequestDTO>> GetByFilterAsync(ActivityFilter filter)
        {
            List<ActivityRequest> activityRequests = (await _activityRequestRepository.FindAsync(filter.ToExpression())).ToList();
            return activityRequests.Select(req => req.ToDTO()).ToList();
        }
    }

}
