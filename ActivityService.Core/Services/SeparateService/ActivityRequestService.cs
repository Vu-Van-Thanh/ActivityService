using System.Linq.Expressions;
using ActivityService.Core.Domain.Entities;
using ActivityService.Core.DTO;
using ActivityService.Core.RepositoryContracts;
using ActivityService.Core.Services.CommonServiceContract;
using AutoMapper;


namespace ActivityService.Core.Services.SeparateService
{
    public interface IActivityRequestService : IService<ActivityRequest, ActivityRequestDTO>
    {
       
    }
    public class ActivityRequestService : Service<ActivityRequest, ActivityRequestDTO>, IActivityRequestService
    {
        public ActivityRequestService(IRepository<ActivityRequest> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }

}
