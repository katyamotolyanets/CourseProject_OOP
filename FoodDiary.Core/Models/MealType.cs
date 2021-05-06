using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.Models
{
    public class MealType: Entity<Guid>
    {
        public string MealName { get; set; }
        public ICollection<ProductSet> ProductSets { get; set; }

    }
}
