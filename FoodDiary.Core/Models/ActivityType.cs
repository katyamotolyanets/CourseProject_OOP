using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.Models
{
    public class ActivityType : Entity<Guid>
    {
        public string ActivityName { get; set; }
        public double ActivityCalories { get; set; }
        public string IconSource { get; set; }
        public ICollection<Activity> Activities { get; set; }
    }
}
