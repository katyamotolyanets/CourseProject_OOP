using FoodDiary.Core.Models;
using FoodDiary.Main.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FoodDiary.Main.ViewModels
{
    public class ActivityViewModel : BaseViewModel
    {
        public static Activity activity { get; set; }
        public UpdateViewCommand UpdateViewCommand { get; set; }
        public ProductSet productSet { get; set; }
        public UserHistory history { get; set; }
        public AddActCommand AddActCommand { get; set; }
        public ActivityViewModel()
        {

            activity = new Activity();
            activity = AddActCommand.Activity;
            history = new UserHistory();
            UpdateViewCommand = new UpdateViewCommand(MainWindow.MyMainView);
            AddActCommand = new AddActCommand(activity, history);
        }
    }
}
