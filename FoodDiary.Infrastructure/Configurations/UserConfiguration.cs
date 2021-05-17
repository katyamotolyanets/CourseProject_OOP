using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FoodDiary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Infrastructure.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.UserName);
            builder.Property(e => e.UserWeight);
            builder.Property(e => e.UserHeight);
            builder.Property(e => e.UserAge);
            builder.Property(e => e.UserSex);
            builder.Property(e => e.Password);
            builder.Property(e => e.UserCalories);
            builder.Property(e => e.PhotoSource);
            builder.HasOne(e => e.UserLifestyle).WithMany(e => e.Users).HasForeignKey(e => e.IDLifestyle);
        }
    }
}
