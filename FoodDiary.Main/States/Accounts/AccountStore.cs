using FoodDiary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Main.States.Accounts
{
    public class AccountStore : IAccountStore
    {

        private User currentAccount;
        public User CurrentAccount
        {
            get
            {
                return currentAccount;
            }
            set
            {
                currentAccount = value;
                SingleCurrentAccount singleCurrentAccount = SingleCurrentAccount.GetInstance();
                singleCurrentAccount.Account = currentAccount;
                StateChanged?.Invoke();
            }
        }
        public event Action StateChanged;
    }

    public sealed class SingleCurrentAccount
    {
        public User Account { get; set; }
        private static SingleCurrentAccount _instance;
        private SingleCurrentAccount()
        {
            Account = new User();
        }

        public static SingleCurrentAccount GetInstance()
        {
            return _instance ?? (_instance = new SingleCurrentAccount());
        }
    }
}
