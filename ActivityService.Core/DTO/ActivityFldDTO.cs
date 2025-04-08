

namespace ActivityService.Core.DTO
{
    public class ActivityFldDTO
    {
        public Guid FieldId { get; set; }
        public Guid ActivityId { get; set; }

        public string FieldType { get; set; }
        public string FieldName { get; set; }
    }
}
