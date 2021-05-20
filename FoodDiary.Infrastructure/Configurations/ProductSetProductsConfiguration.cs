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
    internal sealed class ProductSetProductsConfiguration : IEntityTypeConfiguration<ProductSetProducts>
    {
        public void Configure(EntityTypeBuilder<ProductSetProducts> builder)
        {
            builder.HasKey(e => e.ID);
            builder.HasOne(e => e.Product).WithMany(e => e.ProductSetProducts).HasForeignKey(e => e.ProductID);
            builder.HasOne(e => e.ProductSet).WithMany(e => e.ProductSetProducts).HasForeignKey(e => e.ProductSetID);
            builder.Property(e => e.ProductWeight);
        }
    }
}
