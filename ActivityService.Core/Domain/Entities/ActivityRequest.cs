
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ActivityService.Core.Domain.Entities
{
    public class ActivityRequest
    {
        [Key]
        public Guid RequestId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid ActivityId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string Status { get; set; }

        public string RequestFlds { get; set; }

        public virtual Activity Activity { get; set; }


    }
}
