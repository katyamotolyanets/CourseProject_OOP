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
    public class ProductSetProductsRepository : Repository<ProductSetProducts>, IProductSetProductsRepository
    {
        public ProductSetProducts Find(Guid id) => MakeInclusions().SingleOrDefault(x => x.ID == id);
        public IEnumerable<ProductSetProducts> List(Expression<Func<ProductSetProducts, bool>> predicate = null)
        {
            var query = MakeInclusions().AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.ToList();
        }

        private IQueryable<ProductSetProducts> MakeInclusions() =>
            DbSet.Include(x => x.Product).Include(x => x.ProductSet).ThenInclude(x => x.MealType);
    }
}
