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
    internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.NameProduct);
            builder.Property(e => e.EnergyValue);
            builder.Property(e => e.Calories);
            builder.Property(e => e.Proteins);
            builder.Property(e => e.Fats);
            builder.Property(e => e.Carbohydrates);
        }
    }
}
