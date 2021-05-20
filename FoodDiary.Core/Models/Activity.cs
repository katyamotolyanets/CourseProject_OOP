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
        public int ActivityTime { get; set; }
        public ICollection<UserHistoryActivities> UserHistoryActivities { get; set; }
    }
}
