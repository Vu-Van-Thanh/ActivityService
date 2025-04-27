
using ActivityService.API.Kafka.Producer;
using ActivityService.Core.Domain.Entities;
using ActivityService.Core.DTO;
using ActivityService.Core.RepositoryContracts.SeparateRepository;
using ActivityService.Infrastructure.Kafka.KafkaEntity;

namespace ActivityService.Infrastructure.Kafka.Handlers
{
    public class GetAttendaceHandler : IKafkaHandler<KafkaRequest<AttendaceFilterDTO>>
    {
        private readonly IEventProducer _eventProducer;
        private readonly IAttendanceRepository _attendanceRepository;
        public GetAttendaceHandler( IEventProducer eventProducer, IAttendanceRepository attendanceRepository)
        {
           
            _eventProducer = eventProducer;
            _attendanceRepository = attendanceRepository;
        }
        public async Task HandleAsync(KafkaRequest<AttendaceFilterDTO> message)
        {
            List<Attendance> result = (await _attendanceRepository.FindAsync(message.Filter.ToExpression())).ToList();
            KafkaResponse<List<Attendance>> response = new KafkaResponse<List<Attendance>>()
            {
                RequestType = message.RequestType,
                CorrelationId = message.CorrelationId,
                Timestamp = DateTime.UtcNow,
                Filter = result
            };
            Console.WriteLine($"GetAttendaceHandler: {result}");
            await _eventProducer.PublishAsync("AttendanceList", null, null, response);
            

        }
    }
}
