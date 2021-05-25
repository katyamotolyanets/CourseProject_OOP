using FoodDiary.Core.Models;
using FoodDiary.Core.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Infrastructure.Repositories
{
    public class ActivityRepository : Repository<Activity>, IActivityRepository
    {
        UnitOfWork UnitOfWork { get; set; }
        public UserHistoryActivities UserHistoryActivities { get; set; }
        public Activity Find(Guid id) => MakeInclusions().SingleOrDefault(x => x.ID == id);

        public IEnumerable<Activity> List(Expression<Func<Activity, bool>> predicate = null)
        {
            var query = MakeInclusions().AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return query.ToList();
        }
        private IQueryable<Activity> MakeInclusions() =>
            DbSet.Include(x => x.ActivityType);
        public void Create(Activity activity)
        {
            DbSet.Add(activity);

            Context.SaveChanges();
        }

        public void Delete(Activity activity)
        {
            UnitOfWork = new UnitOfWork();
            
            DbSet.Remove(activity);
 
            Context.SaveChanges();
        }
    }
}
