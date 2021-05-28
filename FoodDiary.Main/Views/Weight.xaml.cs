using FoodDiary.Core.Exceptions;
using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.States.Accounts;
using FoodDiary.Main.ViewModels;
using MaterialDesignThemes.Wpf;
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
    /// Логика взаимодействия для Weight.xaml
    /// </summary>
    public partial class Weight : UserControl
    {
        public WeightViewModel weightViewModel { get; set; }
        public UnitOfWork UnitOfWork { get; set; }
        public ChangeWeight changeWeight { get; set; }
        public double weightChange { get; set; }
        public User CurrentAccount { get; private set; }

        public Weight()
        {
            InitializeComponent();
            DataContext = WeightViewModel.LoadViewModel();
        }

        private void weight_Click(object sender, RoutedEventArgs e)
        {
            var but = sender as Button;
            /*but.Command = new LinkToActCommand();
            but.CommandParameter = but.DataContext;*/

            //but.Command.Execute(but.DataContext);
            but.Command = DialogHost.OpenDialogCommand;

        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                weightViewModel = (WeightViewModel)this.DataContext;
                double weight = double.Parse(weightViewModel.UserWeightCh.Replace('.', ','));

                UnitOfWork = new UnitOfWork();
                weightChange = weight;
                CurrentAccount = SingleCurrentAccount.GetInstance().Account;

                changeWeight = new ChangeWeight();
                changeWeight.ID = Guid.NewGuid();
                changeWeight.IDUser = CurrentAccount.ID;
                changeWeight.Date = DateTime.Now;
                changeWeight.UserWeight = weightChange;

                UnitOfWork.ChangeWeightRepository.Create(changeWeight);

                weightViewModel.GetChanges();
                weightViewModel.RefreshWeight();
                CurrentAccount.UserWeight = weightChange;
                UnitOfWork.AccountRepository.Update(CurrentAccount);
                save.Command = DialogHost.CloseDialogCommand;
            }
            catch (WrongValueException)
            {
                weightViewModel.ErrorMessage = "Вес введён неверно";
            }
            catch(Exception)
            {
                weightViewModel.ErrorMessage = "Неверные данные";
            }

        }

    }
}
