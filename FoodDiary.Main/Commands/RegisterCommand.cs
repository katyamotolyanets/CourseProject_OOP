using FoodDiary.Main.States.Authenticators;
using FoodDiary.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static FoodDiary.Infrastructure.Repositories.AuthenticationRepository;

namespace FoodDiary.Main.Commands
{
    public class RegisterCommand : ICommand
    {
        private readonly RegisterViewModel _registerViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly UpdateViewCommand _registerRenavigator;

        public RegisterCommand(RegisterViewModel registerViewModel, IAuthenticator authenticator)
        {
            _registerViewModel = registerViewModel;
            _authenticator = authenticator;
            _registerRenavigator = new UpdateViewCommand(MainWindow.MyMainView);

            _registerViewModel.PropertyChanged += RegisterViewModel_PropertyChanged;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _registerViewModel.CanRegister;
        }

        public void Execute(object parameter)
        {
            _registerViewModel.ErrorMessage = string.Empty;

            try
            {
                RegistrationResult registrationResult = _authenticator.Register(
                       _registerViewModel.UserName,
                       _registerViewModel.Weight,
                       _registerViewModel.Height,
                       _registerViewModel.Age,
                       _registerViewModel.Sex,
                       _registerViewModel.Lifestyle,
                       _registerViewModel.Password,
                       _registerViewModel.ConfirmPassword
                       );

                switch (registrationResult)
                {
                    case RegistrationResult.Success:
                        _registerRenavigator.Execute("Login");
                        break;
                    case RegistrationResult.PasswordDoNotMatch:
                        _registerViewModel.ErrorMessage = "Password does not match confirm password.";
                        break;
                    case RegistrationResult.EmailAlreadyExist:
                        _registerViewModel.ErrorMessage = "An account for this name already exists.";
                        break;

                    default:
                        _registerViewModel.ErrorMessage = "Registration failed.";
                        break;
                }
            }
            catch (Exception)
            {
                _registerViewModel.ErrorMessage = "Registration failed.";
            }
        }


        private void RegisterViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(RegisterViewModel.CanRegister))
            {
                OnCanExecuteChanged();
            }
        }
        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}

