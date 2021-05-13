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
    internal sealed class ProductSetConfiguration : IEntityTypeConfiguration<ProductSet>
    {
        public void Configure(EntityTypeBuilder<ProductSet> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.ProductWeight);
            builder.Property(e => e.Date);
            builder.HasOne(e => e.MealType).WithMany(e => e.ProductSets).HasForeignKey(e => e.IDType);
            builder.HasOne(e => e.Product).WithMany(e => e.ProductSets).HasForeignKey(e => e.IDProduct);
        }
    }
}
