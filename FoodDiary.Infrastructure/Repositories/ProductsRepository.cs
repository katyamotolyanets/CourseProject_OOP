using FoodDiary.Core.RepositoryInterfaces;
using FoodDiary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace FoodDiary.Infrastructure.Repositories
{
    public class ProductsRepository : Repository<Product>, IProductsRepository
    {
        public Product Find(Guid id) => MakeInclusions().SingleOrDefault(x => x.ID == id);
        public IEnumerable<Product> List(Expression<Func<Product, bool>> predicate = null)
        {
            var query = MakeInclusions().OrderBy(x => x.NameProduct).AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.ToList();
        }

        private IQueryable<Product> MakeInclusions() =>
            DbSet;

        public void Create(Product product)
        {
            DbSet.Add(product);

            Context.SaveChanges();
        }
    }
}
