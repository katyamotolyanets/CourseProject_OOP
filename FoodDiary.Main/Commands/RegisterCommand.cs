using FoodDiary.Core.Exceptions;
using FoodDiary.Main.States.Authenticators;
using FoodDiary.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                if (!Regex.IsMatch(_registerViewModel.Weight.ToString(), @"\d+(\.|\,){0,1}\d{1,2}"))
                {
                    throw new WrongValueException(_registerViewModel.Weight);
                }
                if (!Regex.IsMatch(_registerViewModel.Height.ToString(), @"\d{3}") && _registerViewModel.Height > 250)
                {
                    throw new WrongValueException(_registerViewModel.Height);
                }
                if (!Regex.IsMatch(_registerViewModel.Age.ToString(), @"\d{1,2}"))
                {
                    throw new WrongAgeException(_registerViewModel.Age);
                }
                if (!Regex.IsMatch(_registerViewModel.UserName, @"[A-Za-z]\w{5,17}"))
                {
                    throw new WrongNameException(_registerViewModel.UserName);
                }
                if (!Regex.IsMatch(_registerViewModel.Password, @"\w+"))
                {
                    throw new WrongPasswordException(_registerViewModel.Password);
                }
                RegistrationResult registrationResult = _authenticator.Register(
                       _registerViewModel.UserName,
                       _registerViewModel.Weight,
                       _registerViewModel.Height,
                       _registerViewModel.Age,
                       _registerViewModel.Sex,
                       _registerViewModel.Lifestyle,
                       _registerViewModel.Password,
                       _registerViewModel.ConfirmPassword,
                       _registerViewModel.Photo
                       );

                switch (registrationResult)
                {
                    case RegistrationResult.Success:
                        _registerRenavigator.Execute("Login");
                        break;
                    case RegistrationResult.PasswordDoNotMatch:
                        _registerViewModel.ErrorMessage = "Пароли не совпадают";
                        break;
                    case RegistrationResult.NameAlreadyExist:
                        _registerViewModel.ErrorMessage = "Аккаунт с таким именем уже существует";
                        break;

                    default:
                        _registerViewModel.ErrorMessage = "Не удалось зарегистрироваться";
                        break;
                }
            }
            catch (WrongValueException)
            {
                _registerViewModel.ErrorMessage = "Неверно введены числа";
            }
            catch (WrongAgeException)
            {
                _registerViewModel.ErrorMessage = "Неверно введён возраст";
            }
            catch (WrongNameException)
            {
                _registerViewModel.ErrorMessage = "Имя должно состоять из латинских букв и содержать не менее 5 символов";
            }
            catch (WrongPasswordException)
            {
                _registerViewModel.ErrorMessage = "Пароль может содержать латинские буквы и цифры (не менее 5 символов)";
            }
            catch (Exception)
            {
                _registerViewModel.ErrorMessage = "Не удалось зарегистрироваться";
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

