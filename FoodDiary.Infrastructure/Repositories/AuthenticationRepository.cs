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
            EmailAlreadyExist,
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

        public RegistrationResult Register(string username, double weight, double height, int age, string sex, UserLifestyle lifestyle, string password, string confirmPassword)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (password != confirmPassword)
            {
                result = RegistrationResult.PasswordDoNotMatch;
            }

            User potentiallyExistedUser = _accountRepository.GetByName(username);

            if (potentiallyExistedUser != null)
            {
                result = RegistrationResult.EmailAlreadyExist;
            }

            if (result == RegistrationResult.Success)
            {
                string hashedPassword = _passwordHasher.HashPassword(password);
                Guid guid = new Guid();
                Guid IDLifestyle = lifestyle.ID;

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
                };
                _accountRepository.Create(user);
            }
            return result;
        }
    }

}
