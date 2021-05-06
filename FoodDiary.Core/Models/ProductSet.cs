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
        public Guid IDProduct { get; set; }
        public Product Product { get; set; }
        public float ProductWeight { get; set; }
        public DateTime Date { get; set; }
        public ICollection<UserHistory> UserHistories { get; set; }
    }
}
