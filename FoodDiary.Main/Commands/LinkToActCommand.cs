using FoodDiary.Core.Models;
using FoodDiary.Main.ViewModels;
using FoodDiary.Main.Views;
using MaterialDesignThemes.Wpf;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace FoodDiary.Main.Commands
{
    public class LinkToActCommand : ICommand
    {
        public static ActivityType activityType = new ActivityType();
        public LinkToActCommand()
        {        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            activityType = (ActivityType)parameter;
        }

    }
}
