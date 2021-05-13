using FoodDiary.Core.Models;
using FoodDiary.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Infrastructure.Repositories
{
    public class LifestyleRepository : Repository<UserLifestyle>, ILifestyleRepository
    {
        public UserLifestyle Find(Guid id) => DbSet.SingleOrDefault(x => x.ID == id);

        public IEnumerable<UserLifestyle> List(Expression<Func<UserLifestyle, bool>> predicate = null)
        {
            var query = DbSet.AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return query.ToList();
        }
    }
}
