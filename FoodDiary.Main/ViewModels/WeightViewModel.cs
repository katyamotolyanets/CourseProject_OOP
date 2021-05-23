using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.Commands;
using FoodDiary.Main.States.Accounts;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FoodDiary.Main.ViewModels
{
    public class WeightViewModel : BaseViewModel
    {
        public List<ChangeWeight> ChangesWeight { get; set; }
        public ChangeWeightRepository ChangeWeightRepository { get; set; }
        public AccountRepository AccountRepository { get; set; }
        public User CurrentAccount { get; set; }
        public ChangeWeight ChangeWeight { get; set; }
        private double _lastChange { get; set; }
        public double LastChange
        {
            get
            {
                return _lastChange;
            }
            set
            {
                _lastChange = value;
                OnPropertyChanged(nameof(LastChange));
            }
        }

        private string _last { get; set; }
        public string Last
        {
            get
            {
                return _last;
            }
            set
            {
                _last = value;
                OnPropertyChanged(nameof(Last));
            }
        }

        private double _userWeightCh { get; set; }
        public double UserWeightCh
        {
            get
            {
                return _userWeightCh;
            }
            set
            {
                _userWeightCh = value;
                OnPropertyChanged(nameof(UserWeightCh));
                GetChanges();
                RefreshWeight();
            }
        }
        public ChartValues<double> Values { get; set; }
        public ObservableCollection<string> DateTimes { get; set; }
        public UpdateWeightCommand UpdateWeightCommand { get; set; }
        public UpdateViewCommand UpdateViewCommand { get; set; }
        public WeightViewModel()
        {
            CurrentAccount = SingleCurrentAccount.GetInstance().Account;

            ChangesWeight = new List<ChangeWeight>();
            ChangeWeightRepository = new ChangeWeightRepository();
            AccountRepository = new AccountRepository();

            UpdateWeightCommand = new UpdateWeightCommand(this);

            GetChanges();

            Values = new ChartValues<double>();
            DateTimes = new ObservableCollection<string>();

            GetInfo();

            LastChange = ChangesWeight.Last().UserWeight;

            CurrentAccount.UserWeight = LastChange;
            AccountRepository.Update(CurrentAccount);
            UpdateViewCommand = new UpdateViewCommand(MainWindow.MyMainView);
            RefreshWeight();
            Last = LastChange.ToString("00.0");
        }

        public static WeightViewModel LoadViewModel(Action<Task> onLoaded = null)
        {
            WeightViewModel weightViewModel = new WeightViewModel();
            weightViewModel.GetInfo().ContinueWith(t => onLoaded?.Invoke(t));
            return weightViewModel;
        }

        public async Task GetInfo()
        {
            Values.Clear();
            Values = new ChartValues<double>(ChangesWeight.Select(c => c.UserWeight));
            DateTimes.Clear();
            DateTimes = new ObservableCollection<string>(ChangesWeight.Select(c => c.Date.ToString("dd.MM")));
        }
        public void GetChanges()
        {
            ChangesWeight = (List<ChangeWeight>)ChangeWeightRepository.List(x => x.IDUser == CurrentAccount.ID);
        }

        public void RefreshWeight()
        {
            LastChange = (int)ChangesWeight.Last().UserWeight;
            Last = LastChange.ToString("00.0");

        }
    }
}
