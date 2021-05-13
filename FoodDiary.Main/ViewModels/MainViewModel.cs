using FoodDiary.Core.Models;
using FoodDiary.Main.Commands;
using FoodDiary.Main.States.Accounts;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Input;

namespace FoodDiary.Main.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        private BaseViewModel _currentViewModel;
        public  BaseViewModel CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public ICommand UpdateViewCommand { get; set; }
        public User CurrentAccount { get; set; }

        public bool _isLoggin { get; set; }
        public bool IsLoggin
        {
            get { return _isLoggin; }
            set
            {
                _isLoggin = value;

                OnPropertyChanged(nameof(IsLoggin));
            }
        }
        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
            CheckLoggin();
        }

        public void CheckLoggin()
        {
            SingleCurrentAccount currentAccount = SingleCurrentAccount.GetInstance();
            CurrentAccount = currentAccount.Account;
            if (CurrentAccount.UserName == null)
                IsLoggin = false;
            else
                IsLoggin = true;
        }
    }
}
