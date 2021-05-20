using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.Models
{
    public class ProductSet: Entity<Guid>
    {
        public Guid IDType { get; set; }
        public MealType MealType { get; set; }
        public ICollection<UserHistoryProductSets> UserHistoryProductSets { get; set; }
        public ICollection<ProductSetProducts> ProductSetProducts { get; set; }
    }
}
