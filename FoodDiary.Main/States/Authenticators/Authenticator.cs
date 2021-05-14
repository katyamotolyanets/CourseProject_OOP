using FoodDiary.Core.Models;
using FoodDiary.Core.RepositoryIntarfaces.AuthenticationRepository;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.States.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FoodDiary.Infrastructure.Repositories.AuthenticationRepository;

namespace FoodDiary.Main.States.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly AuthenticationRepository _authenticationRepository;
        private readonly IAccountStore _accountStore;

        public Authenticator(AuthenticationRepository authenticationRepository, IAccountStore accountStore)
        {
            _authenticationRepository = authenticationRepository;
            _accountStore = accountStore;
        }

        public User CurrentAccount
        {
            get
            {
                return _accountStore.CurrentAccount;
            }
            private set
            {
                _accountStore.CurrentAccount = value;
                StateChanged?.Invoke();
            }
        }
        public bool IsLoggedIn => CurrentAccount != null;
        public event Action StateChanged;

        public bool Login(string name, string password)
        {
            bool success = true;
            try
            {
                CurrentAccount = _authenticationRepository.Login(name, password);
            }
            catch (Exception)
            {
                success = false;
            }
            return success;

        }

        public void Logout()
        {
            CurrentAccount = null;
        }

        public RegistrationResult Register(string username, double weight, double height, int age, string sex, UserLifestyle lifestyle, string password, string confirmPassword)
        {
            return _authenticationRepository.Register(username, weight, height, age, sex, lifestyle, password, confirmPassword);
        }
    }
}
