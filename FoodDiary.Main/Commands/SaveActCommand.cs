using FoodDiary.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FoodDiary.Main.Commands
{
    public class SaveActCommand : ICommand
    {
        public static Guid HistoryID { get; set; }
        public DiaryViewModel diaryViewModel { get; set; }
        public event EventHandler CanExecuteChanged;
        
        public SaveActCommand(DiaryViewModel diaryViewModel)
        {
            this.diaryViewModel = diaryViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            HistoryID = (Guid)parameter;
            diaryViewModel.UpdateViewCommand.Execute("Activities");
        }
    }
}
