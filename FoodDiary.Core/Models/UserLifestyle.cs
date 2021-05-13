using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.Models
{
    public class UserLifestyle : Entity<Guid>
    {
        public string LifestyleName { get; set; }
        public double Coefficient { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
