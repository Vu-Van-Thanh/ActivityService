

namespace ActivityService.Core.DTO
{
    public class ActivityRequestDTO
    {
        public Guid RequestId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid ActivityId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Status { get; set; }
        public string RequestFlds { get; set; }
    }
}
