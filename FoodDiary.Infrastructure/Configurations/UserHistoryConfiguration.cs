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
    internal sealed class UserHistoryConfiguration : IEntityTypeConfiguration<UserHistory>
    {
        public void Configure(EntityTypeBuilder<UserHistory> builder)
        {
            builder.HasKey(e => e.ID);
            builder.HasOne(e => e.User).WithMany(e => e.UserHistories).HasForeignKey(e => e.IDUser);
            builder.Property(e => e.Date);
        }
    }
}
