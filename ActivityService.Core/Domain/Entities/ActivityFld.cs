using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActivityService.Core.Domain.Entities
{
    public class ActivityFld
    {
        [Key]
        public Guid FieldId { get; set; }
        public Guid ActivityId { get; set; }
        
        public string FieldType { get; set; }
        public string FieldName { get; set; }

        [ForeignKey("ActivityId")]
        public virtual Activity Activity { get; set; }

    }
}
