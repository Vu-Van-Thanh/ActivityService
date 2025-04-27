
namespace ActivityService.Infrastructure.Kafka.Consumers.Manual
{
    public  interface IEventConsumer
    {
        Task<T> ConsumeAsync<T>(string topic, CancellationToken cancellationToken = default);
    }
}
