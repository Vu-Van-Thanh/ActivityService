
using System.ComponentModel.DataAnnotations;

namespace ActivityService.Core.Domain.Entities
{
    public class Attendance
    {
        [Key]
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
}
