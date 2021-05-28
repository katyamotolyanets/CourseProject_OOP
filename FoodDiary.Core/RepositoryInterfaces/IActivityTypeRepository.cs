using FoodDiary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.RepositoryInterfaces
{
    public interface IActivityTypeRepository : IRepository<ActivityType, Guid>
    {
        void Create(ActivityType activityType);
    }
}
