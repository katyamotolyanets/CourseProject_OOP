using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.Models
{
    public class UserHistoryActivities: Entity<Guid>
    {
        public Guid ActivityID { get; set; }
        public Activity Activity { get; set; }
        public Guid UserHistoryID { get; set; }
        public UserHistory UserHistory { get; set; }
    }
}
