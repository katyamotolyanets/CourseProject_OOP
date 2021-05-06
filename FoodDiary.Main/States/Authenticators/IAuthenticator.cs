using FoodDiary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FoodDiary.Infrastructure.Repositories.AuthenticationRepository.AuthenticationRepository;

namespace FoodDiary.Main.States.Authenticators
{
    public interface IAuthenticator
    {
        User CurrentAccount { get; }
        bool IsLoggedIn { get; }

        event Action StateChanged;
        RegistrationResult Register(string email, string username, string password, string confirmPassword, double balance);
        bool Login(string username, string password);
        void Logout();
    }
}
