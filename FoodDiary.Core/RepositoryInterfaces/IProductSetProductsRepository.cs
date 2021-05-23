using FoodDiary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.RepositoryInterfaces
{
    public interface IProductSetProductsRepository : IRepository<ProductSetProducts, Guid>
    {
        void Create(ProductSetProducts productSetProducts);
        void Edit(ProductSetProducts productSetProducts);
        void Delete(ProductSetProducts productSetProducts);
    }
}
