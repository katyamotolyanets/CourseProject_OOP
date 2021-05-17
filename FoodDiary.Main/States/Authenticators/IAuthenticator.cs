using FoodDiary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FoodDiary.Infrastructure.Repositories.AuthenticationRepository;

namespace FoodDiary.Main.States.Authenticators
{
    public interface IAuthenticator
    {
        User CurrentAccount { get; }
        bool IsLoggedIn { get; }

        event Action StateChanged;
        RegistrationResult Register(string username, double weight, double height, int age, string sex, UserLifestyle lifestyle, string password, string confirmPassword, string photo);
        bool Login(string username, string password);
        void Logout();
    }
}
