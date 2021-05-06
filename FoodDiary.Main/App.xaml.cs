using FoodDiary.Core.RepositoryIntarfaces.AuthenticationRepository;
using FoodDiary.Core.RepositoryInterfaces;
using FoodDiary.Infrastructure;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.States.Accounts;
using FoodDiary.Main.States.Authenticators;
using FoodDiary.Main.ViewModels;
using Microsoft.AspNetCore.Identity;
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
                IServiceProvider serviceProvider = CreateServiceProvider();
                //IAuthenticationRepository authentication = serviceProvider.GetRequiredService<IAuthenticationRepository>();

                //authentication.Login("alexbutner", "Qwer1");
                Window window = serviceProvider.GetRequiredService<MainWindow>();
                window.Show();
                base.OnStartup(e);
            }
            private IServiceProvider CreateServiceProvider()
            {
                IServiceCollection services = new ServiceCollection();

                services.AddSingleton<FoodDiaryContext>();
                services.AddSingleton<IHistoryRepository, HistoryRepository>();
                services.AddSingleton<IAuthenticationRepository, AuthenticationRepository>();
                services.AddSingleton<IAccountRepository, AccountRepository>();

                services.AddSingleton<IPasswordHasher, PasswordHasher>();


                services.AddSingleton<DiaryViewModel>();
                services.AddSingleton<AddNewProductViewModel>();
                services.AddSingleton<EditProductSetViewModel>();
                services.AddSingleton<FilteringViewModel>();
                services.AddSingleton<ProductViewModel>();
                services.AddSingleton<LoginViewModel>();
                services.AddSingleton<RegisterViewModel>();
                services.AddSingleton<BaseViewModel>();


                /* services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
                 services.AddSingleton<CreateViewModel<RegisterViewModel>>(services =>
                 {
                     return () => new RegisterViewModel(
                         services.GetRequiredService<IAuthenticator>()
                         );
                 });
                 services.AddSingleton<ViewModelDelegateRenavigator<RegisterViewModel>>();
                 services.AddSingleton<ViewModelDelegateRenavigator<ProfileViewModel>>();
                 services.AddSingleton<CreateViewModel<LoginViewModel>>(services =>
                 {
                     return () => new LoginViewModel(
                         services.GetRequiredService<IAuthenticator>()
                         );
                 });
     */
                services.AddSingleton<IAuthenticator, Authenticator>();
                services.AddSingleton<IAccountStore, AccountStore>();

                services.AddScoped<MainViewModel>();

                services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
                return services.BuildServiceProvider();

            }
}
