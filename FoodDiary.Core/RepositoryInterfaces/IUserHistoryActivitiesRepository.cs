using FoodDiary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.RepositoryInterfaces
{
    public interface IUserHistoryActivitiesRepository : IRepository<UserHistoryActivities, Guid>
    {
        void Create(UserHistoryActivities userHistoryActivities);
        void Delete(UserHistoryActivities userHistoryActivities);
        UserHistoryActivities FindActivity(Guid id);
    }
}
