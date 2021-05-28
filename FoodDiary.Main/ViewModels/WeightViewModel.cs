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
        public List<ChangeWeight> _changesWeight { get; set; }

        public List<ChangeWeight> ChangesWeight {
            get
            {
                return _changesWeight;
            }
            set
            {
                _changesWeight = value;
                OnPropertyChanged(nameof(ChangesWeight));
            }
        }
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

        private string _userWeightCh { get; set; }
        public string UserWeightCh
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
        public ChartValues<double> _values { get; set; }
        public ChartValues<double> Values {
            get
            {
                return _values;
            }
            set
            {
                _values = value;
                OnPropertyChanged(nameof(Values));
                GetChanges();
                RefreshWeight();
            }
        }
        public ObservableCollection<string> _dateTimes { get; set; }

        public ObservableCollection<string> DateTimes {
            get
            {
                return _dateTimes;
            }
            set
            {
                _dateTimes = value;
                OnPropertyChanged(nameof(DateTimes));
                GetChanges();
                RefreshWeight();
            }
        }
        public UpdateWeightCommand UpdateWeightCommand { get; set; }
        public UpdateViewCommand UpdateViewCommand { get; set; }
        public MessageViewModel ErrorMessageViewModel { get; set; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }
        public WeightViewModel()
        {
            ErrorMessageViewModel = new MessageViewModel();
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
            LastChange = ChangesWeight.Last().UserWeight;
            Last = LastChange.ToString("00.0");

        }
    }
}
