using FoodDiary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.RepositoryInterfaces
{
    public interface IActivityRepository : IRepository<Activity, Guid>
    {
        void Create(Activity activity);
        void Delete(Activity activity);
    }
}
