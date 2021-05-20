using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.Models
{
    public class UserHistoryProductSets : Entity<Guid>
    {
        public Guid ProductSetID { get; set; }
        public ProductSet ProductSet { get; set; }
        public Guid UserHistoryID { get; set; }
        public UserHistory UserHistory { get; set; }
    }
}
