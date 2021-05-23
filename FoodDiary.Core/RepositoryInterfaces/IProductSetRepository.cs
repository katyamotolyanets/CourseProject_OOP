using System;
using FoodDiary.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.RepositoryInterfaces
{
    public interface IProductSetRepository : IRepository<ProductSet, Guid>
    {
        void Create(ProductSet productSet);
        //IEnumerable<Product> GetProducts(Guid ProductSetID);
    }
}
