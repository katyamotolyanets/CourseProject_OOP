using FoodDiary.Core.Models;
using FoodDiary.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Infrastructure.Repositories
{
    public class AccountRepository : Repository<User>, IAccountRepository
    {
        public User Find(Guid id) => DbSet.SingleOrDefault(x => x.ID == id);


        public User GetByName(string name) => DbSet.SingleOrDefault(x => x.UserName == name);

        public IEnumerable<User> List(Expression<Func<User, bool>> predicate = null)
        {
            var query = DbSet.OrderByDescending(x => x.UserName).AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return query.ToList();
        }
        public void Create(User account)
        {
            DbSet.Add(account);
            Context.SaveChanges();
        }

    }
}
