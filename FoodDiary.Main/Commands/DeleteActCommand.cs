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
    public class DeleteActCommand : ICommand
    {
        public DiaryViewModel diaryViewModel { get; set; }
        public UserHistoryActivities UserHistoryActivities { get; set; }
        public UnitOfWork UnitOfWork { get; set; }
        public Activity Activity { get; private set; }

        public DeleteActCommand(DiaryViewModel diaryViewModel)
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
            UnitOfWork = new UnitOfWork();
            Activity = new Activity();
            Activity = (Activity)parameter;
            UnitOfWork.ActivityRepository.Delete(Activity);
            diaryViewModel.BindActivities();
            diaryViewModel.GetCaloriesBalance();

        }
    }
}
