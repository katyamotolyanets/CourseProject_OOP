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
    internal sealed class ChangeWeightConfiguration : IEntityTypeConfiguration<ChangeWeight>
    {
        public void Configure(EntityTypeBuilder<ChangeWeight> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.UserWeight);
            builder.Property(e => e.Date);
            builder.HasOne(e => e.User).WithMany(e => e.ChangesWeight).HasForeignKey(e => e.IDUser);
        }
    }
}
