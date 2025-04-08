
using ActivityService.API.Repositories;
using ActivityService.Core.Domain.Entities;
using ActivityService.Core.RepositoryContracts.SeparateRepository;
using ActivityService.Infrastructure.AppDbContext;


namespace ActivityService.Infrastructure.Repositories
{
    public  class AttendanceRepository : Repository<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

}
