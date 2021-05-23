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
        public float EnergyValue { get; set; }
        public float Calories { get; set; }
        public float Proteins { get; set; }
        public float Fats { get; set; }
        public float Carbohydrates { get; set; }
        public string IconSource { get; set; }
        public ICollection<ProductSetProducts> ProductSetProducts { get; set; }
    }
}
