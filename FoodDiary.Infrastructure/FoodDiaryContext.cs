using Microsoft.EntityFrameworkCore;
using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Infrastructure
{
    public class FoodDiaryContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<ChangeWeight> ChangesWeight { get; set; }
        public DbSet<MealType> MealTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSet> ProductSets { get; set; }
        public DbSet<ProductSetProducts> ProductSetProducts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserHistoryActivities> UserHistoryActivities { get; set; }
        public DbSet<UserHistoryProductSets> UserHistoryProductSets { get; set; }
        public DbSet<UserHistory> UsersHistories { get; set; }
        public DbSet<UserLifestyle> UserLifestyles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(local);Database=FoodDiary.Db;Integrated Security=True");
            //optionsBuilder.UseSqlServer(@"Server=tcp:courseworkoop.database.windows.net,1433;Initial Catalog=FoodDiary;Persist Security Info=False;User ID=Averia;Password=A21veria;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActivityConfiguration());
            modelBuilder.ApplyConfiguration(new ActivityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ChangeWeightConfiguration());
            modelBuilder.ApplyConfiguration(new MealTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSetConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSetProductsConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserHistoryProductSetsConfiguration());
            modelBuilder.ApplyConfiguration(new UserHistoryActivitiesConfiguration());
            modelBuilder.ApplyConfiguration(new UserLifestyleConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
