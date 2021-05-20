using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Core.RepositoryInterfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IHistoryRepository HistoryRepository { get; }
        IAccountRepository AccountRepository { get; }

        void Commit();
    }
}