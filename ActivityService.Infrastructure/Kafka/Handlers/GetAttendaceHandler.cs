
using ActivityService.Infrastructure.Kafka.Producers;
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
            var attendanceDataResponses = result
            .GroupBy(a => a.EmployeeId)  
            .Select(group => new AttendanceDataResponse
            {
                EmployeeId = group.Key.ToString(), 
                Records = group.Select(a => new AttendanceRecord
                {
                    AttendanceId = a.AttendanceId.ToString(),  
                    Date = a.AttendanceDate.Date, 
                    Starttime = a.Starttime,  
                    Endtime = a.Endtime,  
                    HoursWorked = (decimal)(a.Endtime - a.Starttime).TotalHours  
                }).ToList(),
                TotalHours = group.Sum(a => (decimal)(a.Endtime - a.Starttime).TotalHours), 
                TotalDays = group.Select(a => a.AttendanceDate.Date).Distinct().Count() 
            }).ToList();
            KafkaResponse<List<AttendanceDataResponse>> response = new KafkaResponse<List<AttendanceDataResponse>>()
            {
                RequestType = message.RequestType,
                CorrelationId = message.CorrelationId,
                Timestamp = DateTime.UtcNow,
                Filter = attendanceDataResponses
            };
            Console.WriteLine($"GetAttendaceHandler: {result}");
            await _eventProducer.PublishAsync("AttendanceList", null, null, response);
            

        }
    }
}
