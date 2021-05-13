using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.Models
{
    public class UserHistory : Entity<Guid>
    {
        public Guid IDUser { get; set; }
        public User User { get; set; }
        public Guid IDProductSet { get; set; }
        public ProductSet ProductSet { get; set; } 
        public Guid IDActivity { get; set; }
        public Activity Activity { get; set; }
    }
}
