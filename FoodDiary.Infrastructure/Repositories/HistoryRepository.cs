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
    public class HistoryRepository : Repository<UserHistory>, IHistoryRepository
    {
        public UserHistory Find(Guid id) => MakeInclusions().SingleOrDefault(x => x.ID == id);

        public IEnumerable<UserHistory> List(Expression<Func<UserHistory, bool>> predicate = null)
        {
            var query = MakeInclusions().AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return query.ToList();
        }

        public void Delete(Guid id)
        {
            UserHistory history = DbSet.Find(id);
            DbSet.Remove(history);
            Context.SaveChanges();
        }
        //возможно надо по-другому хз
        public void Edit(UserHistory history)
        {
            UserHistory History = DbSet.Find(history.ID);
            /*            History.AccountId = history.Account.Id;
                        History.ActivityId = history.Activity.Id;
                        History.Amount = history.Amount;
                        History.Date = history.Date;
                        History.Description = history.Description;
                        History.IsRepeat = History.IsRepeat;*/
            Context.Entry(History).CurrentValues.SetValues(history);
            /*Delete(history.Id);
            
            Create(history);*/
            Context.SaveChanges();
        }
        public void Create(UserHistory history)
        {
            DbSet.Add(history);

            Context.SaveChanges();
        }
        private IQueryable<UserHistory> MakeInclusions() =>
            DbSet.Include(x => x.User).Include(x => x.ProductSet);
    }
}

