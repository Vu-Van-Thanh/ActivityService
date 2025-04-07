using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PayrollService.Core.Domain.Entities;

namespace PayrollService.Infrastructure.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<SalaryBase> SalaryBases { get; set; }
        public DbSet<SalaryHist> SalaryHists { get; set; }
        public DbSet<SalaryAdjustment> SalaryAdjustments { get; set; }
        public DbSet<SalaryPayment> SalaryPayments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            // Chỉ định precision và scale cho các decimal
            builder.Entity<SalaryAdjustment>()
                .Property(s => s.Amount)
                .HasColumnType("decimal(18, 2)");

            builder.Entity<SalaryAdjustment>()
                .Property(s => s.Percentage)
                .HasColumnType("decimal(5, 2)");

            builder.Entity<SalaryBase>()
                .Property(s => s.BaseSalary)
                .HasColumnType("decimal(18, 2)");

            builder.Entity<SalaryHist>()
                .Property(s => s.NewSalary)
                .HasColumnType("decimal(18, 2)");

            builder.Entity<SalaryHist>()
                .Property(s => s.NewSalaryCoefficient)
                .HasColumnType("decimal(5, 2)");

            builder.Entity<SalaryHist>()
                .Property(s => s.OldSalary)
                .HasColumnType("decimal(18, 2)");

            builder.Entity<SalaryHist>()
                .Property(s => s.OldSalaryCoefficient)
                .HasColumnType("decimal(5, 2)");

            builder.Entity<SalaryPayment>()
                .Property(s => s.NetSalary)
                .HasColumnType("decimal(18, 2)");

            // Seed data
            var bases = LoadSeedData<SalaryBase>("SeedData/SalaryBases.json");
            builder.Entity<SalaryBase>().HasData(bases);

            var hists = LoadSeedData<SalaryHist>("SeedData/SalaryHists.json");
            builder.Entity<SalaryHist>().HasData(hists);

            var adjustments = LoadSeedData<SalaryAdjustment>("SeedData/SalaryAdjustments.json");
            builder.Entity<SalaryAdjustment>().HasData(adjustments);

            var payments = LoadSeedData<SalaryPayment>("SeedData/SalaryPayments.json");
            builder.Entity<SalaryPayment>().HasData(payments);
        }

        private static List<T> LoadSeedData<T>(string filePath)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = Directory.GetParent(baseDirectory).Parent.Parent.Parent.Parent.FullName;
            string fullPath = Path.Combine(projectRoot, "PayrollService.Infrastructure", filePath);


            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"Không tìm thấy file seed data: {fullPath}");

            var jsonData = File.ReadAllText(fullPath);
            var items = JsonSerializer.Deserialize<List<T>>(jsonData) ?? new List<T>();

            return items;
        }
    }
}
