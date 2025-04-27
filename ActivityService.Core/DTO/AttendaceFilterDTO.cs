using ActivityService.Core.Domain.Entities;
using System.Linq.Expressions;


namespace ActivityService.Core.DTO
{
    public class AttendaceFilterDTO
    {
        public DateTime? AttendanceDate { get; set; }
        public DateTime? Starttime { get; set; }
        public DateTime? Endtime { get; set; }
        public Guid? ProjectId { get; set; }
        public string? Position { get; set; }
        public string? EmployeeIDList { get; set; }

        public Expression<Func<Attendance, bool>> ToExpression()
        {
           
        }
    }
}
