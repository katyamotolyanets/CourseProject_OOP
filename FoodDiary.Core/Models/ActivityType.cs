﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.Models
{
    public class ActivityType : Entity<Guid>
    {
        public string ActivityName { get; set; }
        public float ActivityCalories { get; set; }
        public ICollection<Activity> Activities { get; set; }
    }
}