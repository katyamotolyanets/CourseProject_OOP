using System;
using FoodDiary.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.RepositoryInterfaces
{
    public interface IProductsRepository : IRepository<Product, Guid>
    {
    }
}
