
using ActivityService.Core.Domain.Entities;

namespace ActivityService.Core.DTO
{
    public class AttendanceDTO
    {
        public Guid AttendanceId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public DateTime Starttime { get; set; }
        public DateTime Endtime { get; set; }

        public string? Status { get; set; }
        public string? Position { get; set; }
        public string? Description { get; set; }
        public Guid ActivityId { get; set; }
        public Guid ProjectId { get; set; }

    }

    public static class AttendanceDTOExtensions
    {
        public static AttendanceDTO ToDTO(this Attendance attendance)
        {
            return new AttendanceDTO
            {
                AttendanceId = attendance.AttendanceId,
                EmployeeId = attendance.EmployeeId,
                AttendanceDate = attendance.AttendanceDate,
                Starttime = attendance.Starttime,
                Endtime = attendance.Endtime,
                Status = attendance.Status,
                Position = attendance.Position,
                Description = attendance.Description,
                ActivityId = attendance.ActivityId,
                ProjectId = attendance.ProjectId
            };
        }
    }
}
