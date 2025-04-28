namespace  ActivityService.Core.DTO
{
    public class AttendanceDataResponse
    {
        public string EmployeeId { get; set; }
        public List<AttendanceRecord> Records { get; set; }
        public decimal TotalHours { get; set; }
        public float TotalDays { get; set; }
    }

    public class AttendanceRecord
    {
        public string AttendanceId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Starttime { get; set; }
        public DateTime Endtime { get; set; }
        public decimal HoursWorked { get; set; }
        
    }
}