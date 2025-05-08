using ActivityService.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ActivityService.Core.DTO
{
    public class ActivityFilter
    {
        public string? ActivityId { get; set; }
        public string? Status { get; set; }
        public string? EmployeeIdList { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }


        public Expression<Func<ActivityRequest, bool>> ToExpression()
        {
            // Parse danh sách EmployeeId từ chuỗi
            var employeeIdArray = string.IsNullOrWhiteSpace(EmployeeIdList)
                ? new List<Guid>()
                : EmployeeIdList
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(id => Guid.TryParse(id.Trim(), out var guid) ? guid : Guid.Empty)
                    .Where(guid => guid != Guid.Empty)
                    .ToList();

            // Parse ActivityId (nếu có)
            Guid activityGuid = Guid.Empty;
            bool hasActivityId = Guid.TryParse(ActivityId, out activityGuid);

            return activity =>
                (!hasActivityId || activity.ActivityId == activityGuid) &&
                (string.IsNullOrEmpty(Status) || activity.Status == Status) &&
                (!StartDate.HasValue || activity.StartTime >= StartDate.Value) &&
                (!EndDate.HasValue || activity.EndTime <= EndDate.Value) &&
                (!employeeIdArray.Any() || employeeIdArray.Contains(activity.EmployeeId));
        }

    }
}
