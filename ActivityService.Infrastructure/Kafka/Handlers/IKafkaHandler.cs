

namespace ActivityService.Infrastructure.Kafka.Handlers
{
    public interface IKafkaHandler<T>
    {
        Task HandleAsync(T message);

    }
}
