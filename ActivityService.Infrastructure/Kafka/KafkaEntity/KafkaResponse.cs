

namespace ActivityService.Infrastructure.Kafka.KafkaEntity
{
    public class KafkaResponse<T>
    {
        public string RequestType { get; set; } = default!;
        public string CorrelationId { get; set; } = default!;
        public DateTime Timestamp { get; set; }
        public T Filter { get; set; } = default!;
    }
}
