using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.Commands;
using FoodDiary.Main.States.Accounts;
using FoodDiary.Main.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FoodDiary.Main.Views
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : UserControl
    {
        public ProfileViewModel profileViewModel { get; set; }
        public AddPhotoCommand AddPhotoCommand { get; set; }

        public Profile()
        {
            InitializeComponent();
            DataContext = new ProfileViewModel();
            profileViewModel = new ProfileViewModel();
            profileViewModel = (ProfileViewModel)DataContext;
        }

        public User CurrentAccount { get; private set; }
        public AccountRepository accountRepository { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CurrentAccount = profileViewModel.CurrentAccount;
            accountRepository = new AccountRepository();

            OpenFileDialog ofdPicture = new OpenFileDialog();
            ofdPicture.Filter =
                "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            ofdPicture.FilterIndex = 1;
           
            if (ofdPicture.ShowDialog() == true)
                imgPicture.Source = new BitmapImage(new Uri(ofdPicture.FileName));

            CurrentAccount.PhotoSource = imgPicture.Source.ToString();
            accountRepository.Update(profileViewModel.CurrentAccount);
            //photoButton.Command.Execute(AddPhotoCommand);
            
        }
    }
}
