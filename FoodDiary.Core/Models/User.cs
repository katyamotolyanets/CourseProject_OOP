using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.Models
{
    public class User: Entity<Guid>
    {
        public string UserName { get; set; }
        public float UserWeight { get; set; }
        public float UserHeight { get; set; }
        public string UserSex { get; set; }
        public float UserCalories { get; set; }
        public string Password { get; set; }
        public ICollection<UserHistory> UserHistories { get; set; }

    }
}
