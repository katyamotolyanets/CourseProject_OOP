using FoodDiary.Core.Models;
using FoodDiary.Main.ViewModels;
using System;
using System.Windows.Input;

namespace FoodDiary.Main.Commands
{
    public class LinkToActCommand : ICommand
    {
        ActivitiesViewModel activitiesViewModel { get; set; }
        public static ActivityType activityType { get; set; }
        public LinkToActCommand(ActivitiesViewModel activitiesViewModel)
        {
            this.activitiesViewModel = activitiesViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            activitiesViewModel.UpdateViewCommand.Execute("Activity");

            activityType = (ActivityType)parameter;
        }
    }
}
