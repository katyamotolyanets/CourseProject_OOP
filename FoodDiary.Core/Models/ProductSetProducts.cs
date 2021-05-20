using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.Models
{
    public class ProductSetProducts : Entity<Guid>
    {
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
        public Guid ProductSetID { get; set; }
        public ProductSet ProductSet { get; set; }
        public double ProductWeight { get; set; }
    }
}
