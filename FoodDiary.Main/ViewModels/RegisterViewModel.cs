using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.Commands;
using FoodDiary.Main.States.Authenticators;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace FoodDiary.Main.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private string _username;
        public string UserName
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(UserName));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private double _weight;
        public double Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
                OnPropertyChanged(nameof(Weight));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private double _height;
        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                OnPropertyChanged(nameof(Height));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private int _age;
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string _sex;
        public string Sex
        {
            get
            {
                return _sex;
            }
            set
            {
                _sex = value;
                OnPropertyChanged(nameof(Sex));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private UserLifestyle _lifestyle;
        public UserLifestyle Lifestyle
        {
            get
            {
                return _lifestyle;
            }
            set
            {
                _lifestyle = value;
                OnPropertyChanged(nameof(Lifestyle));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private float _calories;
        public float Calories
        {
            get
            {
                return _calories;
            }
            set
            {
                _calories = value;
                OnPropertyChanged(nameof(Age));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
                OnPropertyChanged(nameof(CanRegister));
            }
        }
        private string _photo;
        public string Photo
        {
            get
            {
                return _photo;
            }
            set
            {
                _photo = value;
                OnPropertyChanged(nameof(Photo));
                OnPropertyChanged(nameof(CanRegister));
            }
        }
        public bool CanRegister => !string.IsNullOrEmpty(UserName) &&
            !string.IsNullOrEmpty(Convert.ToString(Weight)) &&
            !string.IsNullOrEmpty(Convert.ToString(Height)) &&
            !string.IsNullOrEmpty(Convert.ToString(Age)) &&
            !string.IsNullOrEmpty(Sex) &&
            !string.IsNullOrEmpty(Convert.ToString(Lifestyle)) &&
            !string.IsNullOrEmpty(Password) &&
            !string.IsNullOrEmpty(ConfirmPassword);

        public ICommand RegisterCommand { get; }

        public ICommand ViewLoginCommand { get; }

        public ICommand UpdateViewCommand { get; set; }
        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public List<UserLifestyle> Lifestyles { get; set; } 
        public LifestyleRepository LifestyleRepository { get; set; }
        public Guid lifestyle { get; set; }
        public RegisterViewModel(IAuthenticator authenticator)
        {
            Lifestyles = new List<UserLifestyle>();
            LifestyleRepository = new LifestyleRepository();
            GetLifestyles();

            ErrorMessageViewModel = new MessageViewModel();

            RegisterCommand = new RegisterCommand(this, authenticator);
            UpdateViewCommand = new UpdateViewCommand(MainWindow.MyMainView);
        }

        public void GetLifestyles()
        {
            Lifestyles = (List<UserLifestyle>)LifestyleRepository.List();
        }
    }
    public class IntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!int.TryParse(value.ToString(), out int d))
                return Binding.DoNothing;
            return d;
        }
    }
    public class DoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!double.TryParse(value.ToString(), out double d))
                return Binding.DoNothing;
            return d;
        }
    }

}

