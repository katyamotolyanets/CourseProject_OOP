using FoodDiary.Core.Exceptions;
using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using FoodDiary.Core.RepositoryIntarfaces.AuthenticationRepository;
using Microsoft.EntityFrameworkCore;

namespace FoodDiary.Infrastructure.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly AccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;

        public enum RegistrationResult
        {
            Success,
            NameAlreadyExist,
            PasswordDoNotMatch
        }

        public AuthenticationRepository(AccountRepository accountRepository, IPasswordHasher passwordHasher)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
        }

        public User Login(string name, string password)
        {
            User storedAccount = _accountRepository.GetByName(name);
            if (storedAccount == null)
            {
                throw new AccountNotFoundException(name);
            }

            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(storedAccount.Password,
                                                                                             password);

            if (passwordResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(name, password);
            }
            return storedAccount;
        }

        public RegistrationResult Register(string username, double weight, double height, int age, string sex, UserLifestyle lifestyle, string password, string confirmPassword, string photo)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (password != confirmPassword)
            {
                result = RegistrationResult.PasswordDoNotMatch;
            }

            User potentiallyExistedUser = _accountRepository.GetByName(username);

            if (potentiallyExistedUser != null)
            {
                result = RegistrationResult.NameAlreadyExist;
            }

            if (result == RegistrationResult.Success)
            {
                string hashedPassword = _passwordHasher.HashPassword(password);
                Guid guid = new Guid();
                Guid IDLifestyle = lifestyle.ID;
                photo = @"..\Assets\user.png";
                User user = new User()
                {
                    ID = guid,
                    UserName = username,
                    UserWeight = weight,
                    UserHeight = height,
                    UserAge = age,
                    UserSex = sex,
                    IDLifestyle = IDLifestyle,
                    Password = hashedPassword,  
                    PhotoSource = photo,
                };
                _accountRepository.Create(user);

                ChangeWeight changeWeight = new ChangeWeight();
                ChangeWeightRepository changeWeightRepository = new ChangeWeightRepository();

                changeWeight.ID = Guid.NewGuid();
                changeWeight.IDUser = user.ID;
                changeWeight.UserWeight = user.UserWeight;
                changeWeight.Date = DateTime.Now;

                changeWeightRepository.Create(changeWeight);
            }
            return result;
        }
    }

}
