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
    public class UserHistoryProductSetsRepository : Repository<UserHistoryProductSets>, IUserHistoryProductSetsRepository
    {
        public UserHistoryProductSets Find(Guid id) => MakeInclusions().SingleOrDefault(x => x.ID == id);

        public IEnumerable<UserHistoryProductSets> List(Expression<Func<UserHistoryProductSets, bool>> predicate = null)
        {
            var query = MakeInclusions().AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return query.ToList();
        }
        private IQueryable<UserHistoryProductSets> MakeInclusions() =>
            DbSet.Include(x => x.ProductSet).ThenInclude(x =>x.MealType).Include(x => x.UserHistory);
        public void Create(UserHistoryProductSets userHistoryProductSets)
        {
            DbSet.Add(userHistoryProductSets);

            Context.SaveChanges();
        }
    }
}
