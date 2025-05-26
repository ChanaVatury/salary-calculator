using Microsoft.EntityFrameworkCore;
using SalaryCalculator.API.Models;

namespace SalaryCalculator.API.DAL
{
    public class SalaryDbContext : DbContext
    {
        public SalaryDbContext(DbContextOptions<SalaryDbContext> options) : base(options) { }
        public DbSet<SalaryCalculationRecord> SalaryCalculations { get; set; }
        public DbSet<PartTimePercent> PartTimePercents { get; set; }
        public DbSet<ProfessionalLevel> ProfessionalLevels { get; set; }
        public DbSet<ManagementLevel> ManagementLevels { get; set; }
        public DbSet<LawBonusGroup> LawBonusGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PartTimePercent>().HasData(
                new PartTimePercent { Id = 1, Percent = 100 },
                new PartTimePercent { Id = 2, Percent = 75 },
                new PartTimePercent { Id = 3, Percent = 50 });

            modelBuilder.Entity<ProfessionalLevel>().HasData(
                new ProfessionalLevel { Id = 1, Name = "מתחיל" },
                new ProfessionalLevel { Id = 2, Name = "מנוסה" });

            modelBuilder.Entity<ManagementLevel>().HasData(
                new ManagementLevel { Id = 1, Name = "ללא", LevelValue = 0 },
                new ManagementLevel { Id = 2, Name = "רמת ניהול 1", LevelValue = 1 },
                new ManagementLevel { Id = 3, Name = "רמת ניהול 2", LevelValue = 2 },
                new ManagementLevel { Id = 4, Name = "רמת ניהול 3", LevelValue = 3 },
                new ManagementLevel { Id = 5, Name = "רמת ניהול 4", LevelValue = 4 }
);

            //modelBuilder.Entity<ManagementLevel>().HasData(
            //    new ManagementLevel { Id = 1, Name = "ללא" },
            //    new ManagementLevel { Id = 2, Name = "רמת ניהול 1" },
            //    new ManagementLevel { Id = 3, Name = "רמת ניהול 2" },
            //    new ManagementLevel { Id = 4, Name = "רמת ניהול 3" },
            //    new ManagementLevel { Id = 5, Name = "רמת ניהול 4" });

            modelBuilder.Entity<LawBonusGroup>().HasData(
                new LawBonusGroup { Id = 1, Name = "קבוצה א'" },
                new LawBonusGroup { Id = 2, Name = "קבוצה ב'" });
        }
    }
}