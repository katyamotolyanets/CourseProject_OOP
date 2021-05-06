using FoodDiary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDiary.Main.States.Accounts
{
    public interface IAccountStore
    {
        User CurrentAccount { get; set; }

        event Action StateChanged;
    }
}
