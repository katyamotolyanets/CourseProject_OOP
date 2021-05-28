using FoodDiary.Core.Models;
using FoodDiary.Main.States.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FoodDiary.Main.Commands
{
    public class LogoutCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SingleCurrentAccount currentAccount = SingleCurrentAccount.GetInstance();
            currentAccount.Account = new User();
            MainWindow.MyMainView.IsLoggin = false;
            new UpdateViewCommand(MainWindow.MyMainView).Execute("Login");
        }
    }
}
