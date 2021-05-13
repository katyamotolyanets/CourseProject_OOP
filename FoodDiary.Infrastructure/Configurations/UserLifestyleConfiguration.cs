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
    internal sealed class UserLifestyleConfiguration : IEntityTypeConfiguration<UserLifestyle>
    {
        public void Configure(EntityTypeBuilder<UserLifestyle> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.LifestyleName);
            builder.Property(e => e.Coefficient);
        }
    }
}
