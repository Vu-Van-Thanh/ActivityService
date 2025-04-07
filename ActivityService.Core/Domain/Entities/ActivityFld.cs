using ActivityService.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PayrollService.Core.Domain.Entities
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
