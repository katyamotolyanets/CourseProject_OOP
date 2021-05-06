using FoodDiary.Core.Models;
using FoodDiary.Core.RepositoryIntarfaces.AuthenticationRepository;
using FoodDiary.Core.RepositoryInterfaces.AuthenticationRepository;
using FoodDiary.Main.States.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FoodDiary.Core.RepositoryInterfaces.AuthenticationRepository.AuthenticationRepository.AuthenticationRepository;
using static FoodDiary.Infrastructure.Repositories.AuthenticationRepository.AuthenticationRepository;

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

        public RegistrationResult Register(string username, float weight, float height, string sex, string password, string confirmPassword)
        {
            return _authenticationRepository.Register(username, weight, height, sex, password, confirmPassword);
        }
    }
}
