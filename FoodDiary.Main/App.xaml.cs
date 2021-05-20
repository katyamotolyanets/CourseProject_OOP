using FoodDiary.Core.Models;
using FoodDiary.Core.RepositoryIntarfaces.AuthenticationRepository;
using FoodDiary.Core.RepositoryInterfaces;
using FoodDiary.Infrastructure;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.States.Accounts;
using FoodDiary.Main.States.Authenticators;
using FoodDiary.Main.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FoodDiary.Main
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SingleCurrentAccount currentAccount = SingleCurrentAccount.GetInstance();
            currentAccount.Account = new AccountRepository().GetByName("katya");
            base.OnStartup(e);
        }
    }
}

