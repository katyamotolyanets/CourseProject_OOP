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
        public DbSet<MealType> MealTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSet> ProductSets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserHistory> UsersHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(local);Database=FoodDiary.Db;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MealTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSetConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserHistoryConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
