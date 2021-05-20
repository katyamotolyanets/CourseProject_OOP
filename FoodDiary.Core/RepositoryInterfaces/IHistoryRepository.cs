using FoodDiary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.RepositoryInterfaces
{
    public interface IHistoryRepository: IRepository<UserHistory, Guid>
    {
        UserHistory GetByDate(DateTime date);
        void Delete(Guid id);
        void Edit(UserHistory history);
        void Create(UserHistory history);
    }
}
