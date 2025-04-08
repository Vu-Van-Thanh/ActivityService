using System.Text.Json;
using ActivityService.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace ActivityService.Infrastructure.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityFld> ActivityFlds { get; set; }
        public DbSet<ActivityRequest> ActivityRequests { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            

            // Seed data
            var activities = LoadSeedData<Activity>("SeedData/Activities.json");
            builder.Entity<Activity>().HasData(activities);

            var activityFlds = LoadSeedData<ActivityFld>("SeedData/ActivityFlds.json");
            builder.Entity<ActivityFld>().HasData(activityFlds);

            var activityRequests = LoadSeedData<ActivityRequest>("SeedData/ActivityRequests.json");
            builder.Entity<ActivityRequest>().HasData(activityRequests);

            var attendances = LoadSeedData<Attendance>("SeedData/Attendances.json");
            builder.Entity<Attendance>().HasData(attendances);
        }

        private static List<T> LoadSeedData<T>(string filePath)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = Directory.GetParent(baseDirectory).Parent.Parent.Parent.Parent.FullName;
            string fullPath = Path.Combine(projectRoot, "ActivityService.Infrastructure", filePath);


            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"Không tìm thấy file seed data: {fullPath}");

            var jsonData = File.ReadAllText(fullPath);
            var items = JsonSerializer.Deserialize<List<T>>(jsonData) ?? new List<T>();

            return items;
        }
    }
}
