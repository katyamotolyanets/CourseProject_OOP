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
   public class UserHistoryActivitiesRepository : Repository<UserHistoryActivities>, IUserHistoryActivitiesRepository
    {
        public UserHistoryActivities Find(Guid id) => MakeInclusions().SingleOrDefault(x => x.ID == id);

        public IEnumerable<UserHistoryActivities> List(Expression<Func<UserHistoryActivities, bool>> predicate = null)
        {
            var query = MakeInclusions().AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return query.ToList();
        }
        private IQueryable<UserHistoryActivities> MakeInclusions() =>
            DbSet.Include(x => x.Activity).ThenInclude(x => x.ActivityType).Include(x => x.UserHistory).ThenInclude(x => x.User);
        public void Create(UserHistoryActivities userHistoryActivities)
        {
            DbSet.Add(userHistoryActivities);

            Context.SaveChanges();
        }
    }
}
