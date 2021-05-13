using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.Models
{
    public class Activity : Entity<Guid>
    {
        public Guid IDActivityType { get; set; }
        public ActivityType ActivityType { get; set; }
        public float ActivityTime { get; set; }
        public ICollection<UserHistory> UserHistories { get; set; }

    }
}
