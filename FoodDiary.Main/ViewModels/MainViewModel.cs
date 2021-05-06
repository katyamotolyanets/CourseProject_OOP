using FoodDiary.Main.Commands;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Input;

namespace FoodDiary.Main.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        private BaseViewModel _currentViewModel;
        public  BaseViewModel CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public ICommand UpdateViewCommand { get; set; }

        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
        }
        
        //public bool OnMoveBack(object obj)
        //{

        //}
        //public bool OnCanMoveBack(object obj)
        //{

        //}
    }
}
