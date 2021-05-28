using FoodDiary.Core.Exceptions;
using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FoodDiary.Main.Commands
{
    public class UpdateWeightCommand : ICommand
    {
        public User CurrentAccount { get; set; }
        public WeightViewModel weightViewModel { get;set; }
        public ChangeWeight changeWeight { get; set; }
        public ChangeWeightRepository changeWeightRepository { get; set; }
        public double weightChange { get; set; }
        public UpdateWeightCommand(WeightViewModel weightViewModel)
        {
            this.weightViewModel = weightViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                double weight = double.Parse(weightViewModel.UserWeightCh.Replace('.', ','));
                CurrentAccount = (User)parameter;

                changeWeightRepository = new ChangeWeightRepository();
                weightChange = weight;

                changeWeight = new ChangeWeight();
                changeWeight.ID = Guid.NewGuid();
                changeWeight.IDUser = CurrentAccount.ID;
                changeWeight.Date = DateTime.Now;
                changeWeight.UserWeight = weightChange;

                changeWeightRepository.Create(changeWeight);
                weightViewModel.UpdateViewCommand.Execute("Weight");
            }
            catch(WrongValueException)
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
