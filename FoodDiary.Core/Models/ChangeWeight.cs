using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.Models
{
    public class ChangeWeight : Entity<Guid>
    {
        public Guid IDUser { get; set; }
        public User User { get; set; }
        public double UserWeight { get; set; }
        public DateTime Date { get; set; }
    }
}
