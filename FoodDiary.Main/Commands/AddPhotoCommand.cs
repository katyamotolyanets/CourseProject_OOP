using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.ViewModels;
using FoodDiary.Main.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FoodDiary.Main.Commands
{
    public class AddPhotoCommand : BaseViewModel, ICommand
    {
        public ProfileViewModel profileViewModel { get; set; }
        private User _user { get; set; }
        public User CurrentAccount
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(CurrentAccount));
            }
        }
        public AccountRepository accountRepository { get; set; }
        public AddPhotoCommand(ProfileViewModel profileViewModel)

        {
            this.profileViewModel = profileViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            CurrentAccount = profileViewModel.CurrentAccount;
            accountRepository = new AccountRepository();

            OpenFileDialog ofdPicture = new OpenFileDialog();
            ofdPicture.Filter =
                "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            ofdPicture.FilterIndex = 1;

            if(ofdPicture.ShowDialog() == true)
                CurrentAccount.PhotoSource =
                    ofdPicture.FileName;
            CurrentAccount.PhotoSource =
                    ofdPicture.FileName;
            accountRepository.Update(profileViewModel.CurrentAccount);
        }
    }
}
