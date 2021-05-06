using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.ViewModels;
using System;
using System.Windows.Input;

namespace FoodDiary.Main.Commands
{
    public class DeleteCommand : ICommand
    {
        public DiaryViewModel diaryViewModel { get; set; }
        public ProductSet ProductSet { get; set; }
        public ProductSetRepository ProductSetRepository { get; set; }

        public DeleteCommand(DiaryViewModel diaryViewModel)
        {
            this.diaryViewModel = diaryViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ProductSetRepository = new ProductSetRepository();
            ProductSet = (ProductSet)parameter;
            ProductSetRepository.Delete(ProductSet);
            diaryViewModel.GetSets();
            diaryViewModel.GetBreakfasts();
            diaryViewModel.GetDinners();
            diaryViewModel.GetLunches();
            diaryViewModel.GetSnacks();
        }
    }
}
