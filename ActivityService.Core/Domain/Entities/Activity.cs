
using PayrollService.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ActivityService.Core.Domain.Entities
{
    public class Activity
    {
        [Key]
        public Guid ActivityId { get; set; } 
        public string ActivityDescription { get; set; }  
        public string ActivityType { get; set; }
        public virtual ICollection<ActivityFld> ActivityFlds { get; set; } 
        public virtual ICollection<ActivityRequest> ActivityRequests { get; set; }

    }
}
