using FoodDiary.Core.Models;
using FoodDiary.Main.ViewModels;
using System;
using System.Windows.Input;

namespace FoodDiary.Main.Commands
{
    public class MediatorCommand : ICommand
    {
        FilteringViewModel filteringViewModel { get; set; }
        public static Product product { get; set; }
        public MediatorCommand(FilteringViewModel filteringViewModel)
        {
            this.filteringViewModel = filteringViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            filteringViewModel.UpdateViewCommand.Execute("Product");

            product = (Product)parameter;
        }
    }
}
