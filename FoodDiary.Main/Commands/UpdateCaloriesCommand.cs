using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FoodDiary.Main.Commands
{
    public class UpdateCaloriesCommand : ICommand
    {
        public User CurrentAccount { get; set; }
        public ProfileViewModel profileViewModel { get; set; }
        public UserLifestyle lifestyle { get; set; }
        public UnitOfWork UnitOfWork { get; set; }

        public event EventHandler CanExecuteChanged;

        public UpdateCaloriesCommand(ProfileViewModel profileViewModel)
        {
            this.profileViewModel = profileViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            UnitOfWork = new UnitOfWork();
            CurrentAccount = new User();
            CurrentAccount = profileViewModel.CurrentAccount;
            lifestyle = new UserLifestyle();
            lifestyle = UnitOfWork.LifestyleRepository.Find(CurrentAccount.IDLifestyle);
            
            if (CurrentAccount.UserSex == "женский")
                CurrentAccount.UserCalories = (447.6 + 9.2 * CurrentAccount.UserWeight + 4.8 * CurrentAccount.UserHeight - 5.7 * CurrentAccount.UserAge) * lifestyle.Coefficient;
            else
                CurrentAccount.UserCalories = (88.36 + 13.4 * CurrentAccount.UserWeight + 3.1 * CurrentAccount.UserHeight - 4.3 * CurrentAccount.UserAge) * lifestyle.Coefficient;
            UnitOfWork.AccountRepository.Update(CurrentAccount);
            profileViewModel.Calories = (int)CurrentAccount.UserCalories;
            profileViewModel.GetChanges();
        }
    }
}
