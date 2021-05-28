using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.Models
{
    public class Product: Entity<Guid>
    {
        public string NameProduct { get; set; }
        public double EnergyValue { get; set; }
        public double Calories { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public string IconSource { get; set; }
        public ICollection<ProductSetProducts> ProductSetProducts { get; set; }
    }
}
