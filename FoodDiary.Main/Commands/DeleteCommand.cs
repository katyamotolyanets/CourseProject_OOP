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
        public ProductSetProducts ProductSetProducts { get; set; }
        public UnitOfWork UnitOfWork { get; set; }

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
            UnitOfWork = new UnitOfWork();
            ProductSetProducts = (ProductSetProducts)parameter;
            UnitOfWork.ProductSetProductsRepository.Delete(ProductSetProducts);
            diaryViewModel.BindProductSets();
            diaryViewModel.GetCaloriesBalance();

        }
    }
}
