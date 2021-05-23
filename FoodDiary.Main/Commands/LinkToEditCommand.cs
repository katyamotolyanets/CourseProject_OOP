using FoodDiary.Main.ViewModels;
using FoodDiary.Core.Models;
using System;
using System.Windows.Input;

namespace FoodDiary.Main.Commands
{
    public class LinkToEditCommand : BaseViewModel, ICommand
    {
        DiaryViewModel diaryViewModel { get; set; }
        public static ProductSetProducts ProductSetProduct { get; set; }

        public LinkToEditCommand(DiaryViewModel diaryViewModel)
        {
            this.diaryViewModel = diaryViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ProductSetProduct = (ProductSetProducts)parameter;

            diaryViewModel.UpdateViewCommand.Execute("EditProductSet");
        }
    }
}