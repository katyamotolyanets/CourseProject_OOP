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
        public DateTime Date { get; set; }
        public ICollection<UserHistoryActivities> UserHistoryActivities { get; set; }
        public ICollection<UserHistoryProductSets> UserHistoryProductSets { get; set; }

    }
}
