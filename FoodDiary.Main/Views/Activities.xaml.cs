using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.Commands;
using FoodDiary.Main.States.Accounts;
using FoodDiary.Main.ViewModels;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FoodDiary.Main.Views
{
    /// <summary>
    /// Логика взаимодействия для Activities.xaml
    /// </summary>
    public partial class Activities : UserControl
    {
        public static Activity activity { get; set; }
        public UpdateViewCommand UpdateViewCommand { get; set; }
        public UserHistory history { get; set; }
        public User CurrentAccount { get; private set; }
        public ActivitiesViewModel activitiesViewModel { get; set; }
        public ActivityType activityType = new ActivityType();
        public ActivityRepository activityRepository = new ActivityRepository();
        public HistoryRepository historyRepository = new HistoryRepository();
        public Activities()
        {
            InitializeComponent();
            DataContext = new ActivitiesViewModel();
            
        }

        private void AddAct(object sender, RoutedEventArgs e)
        {
            SingleCurrentAccount currentAccount = SingleCurrentAccount.GetInstance();
            CurrentAccount = currentAccount.Account;
            activitiesViewModel = (ActivitiesViewModel)this.DataContext;
            activity = new Activity();
            activity = activitiesViewModel.Activity;
            activityType = LinkToActCommand.activityType;
            history = new UserHistory();
            activity.ID = Guid.NewGuid();
            activity.IDActivityType = activityType.ID;

            activityRepository.Create(activity);

            history.ID = Guid.NewGuid();
            history.IDActivity = activity.ID;
            history.IDUser = CurrentAccount.ID;

            historyRepository.Create(history);
        }

        private void ShowCanvas(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            btn.Command.Execute(btn.CommandParameter);
            activityType = (ActivityType)btn.CommandParameter;
            activitiesViewModel = (ActivitiesViewModel)this.DataContext;
            activitiesViewModel.ActivityType = activityType;
            ActivityCanvas.Visibility = Visibility.Visible;
        }



        //private void Button_Mouse(object sender, RoutedEventArgs e)
        //{
        //    myPop.IsOpen = true;
        //}

        //private void Close(object sender, RoutedEventArgs e)
        //{
        //    myPop.IsOpen = false;
        //}

    }
}
