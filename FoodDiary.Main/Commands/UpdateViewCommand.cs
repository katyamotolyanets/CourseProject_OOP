using FoodDiary.Core.Models;
using FoodDiary.Core.RepositoryInterfaces;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.States.Accounts;
using FoodDiary.Main.States.Authenticators;
using FoodDiary.Main.ViewModels;
using System;
using System.Windows.Input;

namespace FoodDiary.Main.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            if (parameter.ToString() == "Diary")
            {
                viewModel.CurrentViewModel = new DiaryViewModel();
            }
            else if (parameter.ToString() == "Filtering")
            {
                viewModel.CurrentViewModel = new FilteringViewModel();
            }
            else if (parameter.ToString() == "Product")
            {
                viewModel.CurrentViewModel = new ProductViewModel();
            }
            else if (parameter.ToString() == "AddNewProduct")
            {
                viewModel.CurrentViewModel = new AddNewProductViewModel();
            }
            else if (parameter.ToString() == "EditProductSet")
            {
                viewModel.CurrentViewModel = new EditProductSetViewModel();
            }
            else if (parameter.ToString() == "Activities")
            {
                viewModel.CurrentViewModel = new ActivitiesViewModel();
            }
            else if (parameter.ToString() == "Profile")
            {
                viewModel.CurrentViewModel = new ProfileViewModel();
            }
            else if (parameter.ToString() == "Weight")
            {
                viewModel.CurrentViewModel = new WeightViewModel();
            }
            else if (parameter.ToString() == "Login")
            {
                viewModel.CurrentViewModel = (new LoginViewModel(new Authenticator(new AuthenticationRepository(new AccountRepository(), new Microsoft.AspNet.Identity.PasswordHasher()), new AccountStore())));
            }
            else if (parameter.ToString() == "Register")
            {
                viewModel.CurrentViewModel = (new RegisterViewModel(new Authenticator(new AuthenticationRepository(new AccountRepository(), new Microsoft.AspNet.Identity.PasswordHasher()), new AccountStore())));
            }
        }
    }
}
