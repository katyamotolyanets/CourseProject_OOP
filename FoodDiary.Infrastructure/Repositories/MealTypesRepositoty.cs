using FoodDiary.Core.RepositoryInterfaces;
using FoodDiary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace FoodDiary.Infrastructure.Repositories
{
    public class MealTypesRepository : Repository<MealType>, IMealTypeRepository
    {
        public MealType Find(Guid id) => MakeInclusions().SingleOrDefault(x => x.ID == id);
        public IEnumerable<MealType> List(Expression<Func<MealType, bool>> predicate = null)
        {
            var query = MakeInclusions().OrderBy(x => x.ID).AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.ToList();
        }

        private IQueryable<MealType> MakeInclusions() =>
            DbSet;

        public void Create(MealType mealType)
        {
            DbSet.Add(mealType);

            Context.SaveChanges();
        }
    }
}
