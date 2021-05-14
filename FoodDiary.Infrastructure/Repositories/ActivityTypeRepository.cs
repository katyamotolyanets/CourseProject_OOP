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
    public class ActivityTypeRepository : Repository<ActivityType>, IActivityTypeRepository
    {
        public ActivityType Find(Guid id) => MakeInclusions().SingleOrDefault(x => x.ID == id);

        public IEnumerable<ActivityType> List(Expression<Func<ActivityType, bool>> predicate = null)
        {
            var query = MakeInclusions().AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return query.ToList();
        }
        private IQueryable<ActivityType> MakeInclusions() =>
            DbSet.Include(x => x.Activities);
    }
}
