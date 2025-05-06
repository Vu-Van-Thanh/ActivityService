using ActivityService.Infrastructure.Kafka.Producers;
using ActivityService.API.Repositories;
using ActivityService.Core.DTO;
using ActivityService.Core.Extensions;
using ActivityService.Core.RepositoryContracts;
using ActivityService.Core.RepositoryContracts.SeparateRepository;
using ActivityService.Core.Services.CommonServiceContract;
using ActivityService.Core.Services.SeparateService;
using ActivityService.Infrastructure.AppDbContext;
using ActivityService.Infrastructure.Kafka.Handlers;
using ActivityService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using EmployeeService.Infrastructure.Kafka.Consumers;
using ActivityService.Infrastructure.Kafka;


namespace ActivityServiceRegistry
{
    public static class ConfigureServicesExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });


            // thêm service
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<,>), typeof(Service<,>));
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IActivityFldRepository, ActivityFldRepository>();
            services.AddScoped<IActivityRequestRepository, ActivityRequestRepository>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IActivityService, ActivitiesService>();
            services.AddScoped<IActivityFldService, ActivityFldService>();
            services.AddScoped<IActivityRequestService, ActivityRequestService>();
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<IKafkaHandler<KafkaRequest<AttendaceFilterDTO>>, GetAttendaceHandler>();
            services.AddScoped<IEventProducer, ActivityProducer>();
            services.AddHostedService<ActivityConsumer>();
            services.Configure<KafkaSettings>(configuration.GetSection("Kafka"));
            // cấu hình swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Activity API",
                    Version = "v1",
                    Description = "API quản lý người dùng trong hệ thống microservices",
                    Contact = new OpenApiContact
                    {
                        Name = "Hỗ trợ API",
                        Email = "vut4262@gmail.com",
                        Url = new Uri("https://example.com")
                    }
                });
     
            });

            return services;
        }
    }
}
