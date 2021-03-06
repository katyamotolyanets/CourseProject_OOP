using FoodDiary.Core.RepositoryInterfaces;
using FoodDiary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FoodDiary.Infrastructure.Repositories
{
    public class ProductSetRepository : Repository<ProductSet>, IProductSetRepository
    {
        public ProductSet Find(Guid id) => MakeInclusions().SingleOrDefault(x => x.ID == id);
        public IEnumerable<ProductSet> List(Expression<Func<ProductSet, bool>> predicate = null)
        {
            var query = MakeInclusions().AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.ToList();
        }
        
        private IQueryable<ProductSet> MakeInclusions() =>
            DbSet.Include(x => x.MealType);

        //public IEnumerable<Product> GetProducts(Guid ProductSetID) 
        //{
        //    var query = new List<ProductSetProducts>();
        //    query = query.Where(q => q.ProductSetID == ProductSetID).ToList();
        //    var products = new List<Product>();
        //    foreach(var item in query)
        //    {
        //        products.Add(item.Product);
        //    }
        //    return products;
        //}

        public void Create(ProductSet productSet)
        {
            DbSet.Add(productSet);

            Context.SaveChanges();
        }

        public void Delete(ProductSet productSet)
        {
            DbSet.Remove(productSet);

            Context.SaveChanges();
        }

       
    }
}
