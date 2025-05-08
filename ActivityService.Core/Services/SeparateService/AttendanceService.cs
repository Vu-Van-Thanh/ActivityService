using ActivityService.Core.Domain.Entities;
using ActivityService.Core.DTO;
using ActivityService.Core.RepositoryContracts;
using ActivityService.Core.RepositoryContracts.SeparateRepository;
using ActivityService.Core.Services.CommonServiceContract;
using AutoMapper;
using System.Linq.Expressions;


namespace ActivityService.Core.Services.SeparateService
{
    public interface IAttendanceService : IService<Attendance, AttendanceDTO>
    {
        Task<IEnumerable<AttendanceDTO>> GetAttendaceByFilter(Expression<Func<Attendance, bool>> filter);
    }

    public class AttendanceService : Service<Attendance, AttendanceDTO>, IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IRepository<Attendance> repository, IMapper mapper, IAttendanceRepository attendanceRepository ) : base(repository, mapper)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<IEnumerable<AttendanceDTO>> GetAttendaceByFilter(Expression<Func<Attendance, bool>> filter)
        {
            var attendances = await _attendanceRepository.FindAsync(filter);
            return attendances.Select(attendances => attendances.ToDTO()).ToList(); 
        }
    }
}
