using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.Models
{
    public class Entity
    {    
    }
    public abstract class Entity<T> : Entity
    {
        public T ID { get; set; }
    }
}
