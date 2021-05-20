using FoodDiary.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Infrastructure.Configurations
{
    internal sealed class UserHistoryActivitiesConfiguration : IEntityTypeConfiguration<UserHistoryActivities>
    {
        public void Configure(EntityTypeBuilder<UserHistoryActivities> builder)
        {
            builder.HasKey(e => e.ID);
            builder.HasOne(e => e.Activity).WithMany(e => e.UserHistoryActivities).HasForeignKey(e => e.ActivityID);
            builder.HasOne(e => e.UserHistory).WithMany(e => e.UserHistoryActivities).HasForeignKey(e => e.UserHistoryID);
        }
    }
}
