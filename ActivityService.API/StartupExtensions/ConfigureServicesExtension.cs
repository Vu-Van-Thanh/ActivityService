
using DepartmentService.API.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PayrollService.Core.Extensions;
using PayrollService.Core.RepositoryContracts;
using PayrollService.Core.RepositoryContracts.SeparateRepository;
using PayrollService.Core.Services.CommonServiceContract;
using PayrollService.Core.Services.PaymentService;
using PayrollService.Core.Services.SeparateService;
using PayrollService.Infrastructure.AppDbContext;
using PayrollService.Infrastructure.Repositories;

namespace PayrollServiceRegistry
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
            services.AddScoped<ISalaryAdjustmentRepository, SalaryAdjustmentRepository>();
            services.AddScoped<ISalariesBaseRepository, SalaryBaseRepository>();
            services.AddScoped<ISalaryHistRepository, SalaryHistRepository>();
            services.AddScoped<ISalaryPaymentRepository, SalaryPaymentRepository>();
            services.AddScoped<ISalaryPaymentRepository, SalaryPaymentRepository>();
            services.AddScoped<ISalaryPaymentService, SalaryPaymentService>();
            services.AddScoped<ISalaryAdjustmentService, SalaryAdjustmentService>();
            services.AddScoped<ISalaryBaseService, SalaryBaseService>();
            services.AddScoped<ISalaryHistService, SalaryHistService>();
            // cấu hình swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Payroll API",
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
            services.AddScoped<IVnPayService, VnPayService>();

            return services;
        }
    }
}
