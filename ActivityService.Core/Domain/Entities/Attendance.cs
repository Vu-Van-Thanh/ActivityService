using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollService.Core.Domain.Entities
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
