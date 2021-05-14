using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.States.Accounts;
using FoodDiary.Main.ViewModels;
using System;
using System.Windows.Input;

namespace FoodDiary.Main.Commands
{
    public class AddActCommand : ICommand
    {
        public Activity Activity { get; set; }
        public ActivityRepository activityRepository = new ActivityRepository();
        public UserHistory History { get; set; }
        public HistoryRepository historyRepository = new HistoryRepository();
        public ActivityType activityType { get; set; }
        public ActivityViewModel activityViewModel { get; set; }
        public DiaryViewModel diaryViewModel { get; set; }
        public User CurrentAccount { get; set; }


        public AddActCommand(Activity activity, UserHistory history)
        {
            Activity = activity;
            History = history;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SingleCurrentAccount currentAccount = SingleCurrentAccount.GetInstance();
            CurrentAccount = currentAccount.Account;
            activityType = LinkToActCommand.activityType;
            activityViewModel = new ActivityViewModel();


            Activity = ActivityViewModel.activity;
            Activity.ID = Guid.NewGuid();
            Activity.IDActivityType = activityType.ID;

            activityRepository.Create(Activity);

            History.ID = Guid.NewGuid();
            History.IDActivity = Activity.ID;
            History.IDUser = CurrentAccount.ID;

            historyRepository.Create(History);

            activityViewModel.UpdateViewCommand.Execute("Activities");
        }
    }
}
