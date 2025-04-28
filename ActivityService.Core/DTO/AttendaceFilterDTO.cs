using ActivityService.Core.Domain.Entities;
using System.Linq.Expressions;


namespace ActivityService.Core.DTO
{
    public class AttendaceFilterDTO
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? Starttime { get; set; }
        public DateTime? Endtime { get; set; }
        public Guid? ProjectId { get; set; }
        public string? Position { get; set; }
        public string? EmployeeIDList { get; set; }

        
        public Expression<Func<Attendance, bool>> ToExpression()
        {
            var employeeGuids = new List<Guid>();

            if (!string.IsNullOrWhiteSpace(EmployeeIDList))
            {
                employeeGuids = EmployeeIDList
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(id => Guid.TryParse(id.Trim(), out var guid) ? guid : Guid.Empty)
                    .Where(guid => guid != Guid.Empty)
                    .ToList();
            }

            return attendance =>
                (!StartDate.HasValue || attendance.AttendanceDate.Date >= StartDate.Value.Date) &&
                (!EndDate.HasValue || attendance.AttendanceDate.Date <= EndDate.Value.Date) &&
                (!Starttime.HasValue || attendance.Starttime >= Starttime.Value) &&
                (!Endtime.HasValue || attendance.Endtime <= Endtime.Value) &&
                (!ProjectId.HasValue || attendance.ProjectId == ProjectId.Value) &&
                (string.IsNullOrEmpty(Position) || attendance.Position == Position) &&
                (employeeGuids.Count == 0 || employeeGuids.Contains(attendance.EmployeeId));
        }
    }
}
