using FoodDiary.Main.ViewModels;
using System;
using System.Windows.Input;

namespace FoodDiary.Main.Commands
{
    public class LinkToAddCommand : ICommand
    {
        DiaryViewModel diaryViewModel { get; set; }
        public static Guid MealType { get; set; }
        public LinkToAddCommand(DiaryViewModel diaryViewModel)
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
            diaryViewModel.UpdateViewCommand.Execute("Filtering");

            MealType = Guid.Parse((string)parameter);
        }
    }
}
