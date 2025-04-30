namespace ActivityService.Infrastructure.Kafka.Producers
{
    public interface IEventProducer
    {
        Task PublishAsync<T>(string topic, int? partition, string? key,T @event);
    }

}
