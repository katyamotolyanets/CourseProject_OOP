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
    internal sealed class UserHistoryProductSetsConfiguration : IEntityTypeConfiguration<UserHistoryProductSets>
    {
        public void Configure(EntityTypeBuilder<UserHistoryProductSets> builder)
        {
            builder.HasKey(e => e.ID);
            builder.HasOne(e => e.UserHistory).WithMany(e => e.UserHistoryProductSets).HasForeignKey(e => e.UserHistoryID);
            builder.HasOne(e => e.ProductSet).WithMany(e => e.UserHistoryProductSets).HasForeignKey(e => e.ProductSetID);
        }
    }
}
