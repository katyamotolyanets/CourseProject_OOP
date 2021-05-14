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
            UserLifestyle lifestyle = new UserLifestyle();
            lifestyle = new LifestyleRepository().Find(account.IDLifestyle);
            if (account.UserSex == "женский")
                account.UserCalories = (447.6 + 9.2 * account.UserWeight + 4.8 * account.UserHeight - 5.7 * account.UserAge) * lifestyle.Coefficient;
            else
                account.UserCalories = (88.36 + 13.4 * account.UserWeight + 3.1 * account.UserHeight - 4.3 * account.UserAge) * lifestyle.Coefficient;
            DbSet.Add(account);
            Context.SaveChanges();
        }

    }
}
