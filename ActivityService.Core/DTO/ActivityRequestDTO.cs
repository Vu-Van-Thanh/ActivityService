

using ActivityService.Core.Domain.Entities;

namespace ActivityService.Core.DTO
{
    public class ActivityRequestDTO
    {
        public Guid RequestId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid ActivityId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? StartTime  { get; set; }
        public DateTime? EndTime { get; set; }
        public string Status { get; set; }
        public string RequestFlds { get; set; }
    }
    public static class ActivityRequestDTOExtensions
    {
        public static ActivityRequestDTO ToDTO(this ActivityRequest activityRequest)
        {
            return new ActivityRequestDTO
            {
                RequestId = activityRequest.RequestId,
                EmployeeId = activityRequest.EmployeeId,
                ActivityId = activityRequest.ActivityId,
                CreatedAt = activityRequest.CreatedAt,
                StartTime = activityRequest.StartTime,
                EndTime = activityRequest.EndTime,
                Status = activityRequest.Status,
                RequestFlds = activityRequest.RequestFlds
            };
        }
    }
}
