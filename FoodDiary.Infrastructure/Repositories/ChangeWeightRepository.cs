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
    public class ChangeWeightRepository : Repository<ChangeWeight>, IChangeWeightRepository
    {
        public ChangeWeight Find(Guid id) => MakeInclusions().SingleOrDefault(x => x.ID == id);

        public IEnumerable<ChangeWeight> List(Expression<Func<ChangeWeight, bool>> predicate = null)
        {
            var query = MakeInclusions().AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return query.ToList();
        }
        private IQueryable<ChangeWeight> MakeInclusions() =>
            DbSet;
        public void Create(ChangeWeight changeWeight)
        {
            DbSet.Add(changeWeight);

            Context.SaveChanges();
        }
    }
}
