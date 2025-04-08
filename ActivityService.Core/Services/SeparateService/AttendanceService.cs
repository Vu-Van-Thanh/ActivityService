using ActivityService.Core.Domain.Entities;
using ActivityService.Core.DTO;
using ActivityService.Core.RepositoryContracts;
using ActivityService.Core.Services.CommonServiceContract;
using AutoMapper;


namespace ActivityService.Core.Services.SeparateService
{
    public interface IAttendanceService : IService<Attendance, AttendanceDTO>
    {
        
    }

    public class AttendanceService : Service<Attendance, AttendanceDTO>, IAttendanceService
    {

        public AttendanceService(IRepository<Attendance> repository, IMapper mapper) : base(repository, mapper)
        {
        }
       
    }
}
