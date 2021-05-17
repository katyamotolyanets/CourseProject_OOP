using FoodDiary.Core.Models;
using FoodDiary.Main.Commands;
using FoodDiary.Main.States.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FoodDiary.Main.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private User _user { get; set; }
        public User CurrentAccount 
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(CurrentAccount));
            }
        }
        private double _proteins { get; set; }
        public double Proteins
        {
            get
            {
                return _proteins;
            }
            set
            {
                _proteins = value;
                OnPropertyChanged(nameof(Proteins));
            }
        }
        private double _fats { get; set; }
        public double Fats
        {
            get
            {
                return _fats;
            }
            set
            {
                _fats = value;
                OnPropertyChanged(nameof(Fats));
            }
        }
        private double _carbohydrates { get; set; }
        public double Carbohydrates
        {
            get
            {
                return _carbohydrates;
            }
            set
            {
                _carbohydrates = value;
                OnPropertyChanged(nameof(Carbohydrates));
            }
        }
        private int _looseWeight { get; set; }
        public int LooseWeight
        {
            get
            {
                return _looseWeight;
            }
            set
            {
                _looseWeight = value;
                OnPropertyChanged(nameof(LooseWeight));
            }
        }
        private double _proteinsL { get; set; }
        public double ProteinsL
        {
            get
            {
                return _proteinsL;
            }
            set
            {
                _proteinsL = value;
                OnPropertyChanged(nameof(ProteinsL));
            }
        }
        private double _fatsL { get; set; }
        public double FatsL
        {
            get
            {
                return _fatsL;
            }
            set
            {
                _fatsL = value;
                OnPropertyChanged(nameof(FatsL));
            }
        }
        private double _carbohydratesL { get; set; }
        public double CarbohydratesL
        {
            get
            {
                return _carbohydratesL;
            }
            set
            {
                _carbohydratesL = value;
                OnPropertyChanged(nameof(CarbohydratesL));
            }
        }
        private int _gainWeight { get; set; }
        public int GainWeight
        {
            get
            {
                return _gainWeight;
            }
            set
            {
                _gainWeight = value;
                OnPropertyChanged(nameof(GainWeight));
            }
        }
        private double _proteinsG { get; set; }
        public double ProteinsG
        {
            get
            {
                return _proteinsG;
            }
            set
            {
                _proteinsG = value;
                OnPropertyChanged(nameof(ProteinsG));
            }
        }
        private double _fatsG { get; set; }
        public double FatsG
        {
            get
            {
                return _fatsG;
            }
            set
            {
                _fatsG = value;
                OnPropertyChanged(nameof(FatsG));
            }
        }
        private double _carbohydratesG { get; set; }
        public double CarbohydratesG
        {
            get
            {
                return _carbohydratesG;
            }
            set
            {
                _carbohydratesG = value;
                OnPropertyChanged(nameof(CarbohydratesG));
            }
        }
        private double _calories { get; set; }
        public double Calories
        {
            get
            {
                return _calories;
            }
            set
            {
                _calories = value;
                OnPropertyChanged(nameof(Calories));
            }
        }
        public AddPhotoCommand AddPhotoCommand { get; set; }
        public ProfileViewModel()
        {
            SingleCurrentAccount currentAccount = SingleCurrentAccount.GetInstance();
            CurrentAccount = currentAccount.Account;

            Calories = (int)CurrentAccount.UserCalories;
            AddPhotoCommand = new AddPhotoCommand(this);
            Proteins = (int)((CurrentAccount.UserCalories * 0.2) / 4.134);
            Fats = (int)((CurrentAccount.UserCalories * 0.3) / 9.22); 
            Carbohydrates = (int)((CurrentAccount.UserCalories * 0.5) / 4.095);

            LooseWeight = (int)(CurrentAccount.UserCalories * 0.8);
            ProteinsL = (int)((LooseWeight * 0.2) / 4.134);
            FatsL = (int)((LooseWeight * 0.3) / 9.22);
            CarbohydratesL = (int)((LooseWeight * 0.5) / 4.095);

            GainWeight = (int)(CurrentAccount.UserCalories * 1.2);
            ProteinsG = (int)((GainWeight * 0.2) / 4.134);
            FatsG = (int)((GainWeight * 0.3) / 9.22);
            CarbohydratesG = (int)((GainWeight * 0.5) / 4.095);
        }
    }
}
