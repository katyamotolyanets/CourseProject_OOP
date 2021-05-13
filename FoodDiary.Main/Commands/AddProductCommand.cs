using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.States.Accounts;
using FoodDiary.Main.ViewModels;
using System;
using System.Windows.Input;

namespace FoodDiary.Main.Commands
{
    public class AddProductCommand : DiaryViewModel, ICommand
    {
        public new ProductSet ProductSet { get; set; }
        public ProductSetRepository productSetRepository = new ProductSetRepository();
        public new UserHistory History { get; set; }
        public HistoryRepository historyRepository = new HistoryRepository();
        public Product product { get; set; }
        public Guid mealType { get; set; }
        public ProductViewModel productViewModel { get; set; }
        public DiaryViewModel diaryViewModel { get; set; }
        public new User CurrentAccount { get; set; }

        
        public AddProductCommand(ProductSet productSet, UserHistory history)
        {
            ProductSet = productSet;
            History = history;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SingleCurrentAccount currentAccount = SingleCurrentAccount.GetInstance();
            CurrentAccount = currentAccount.Account;
            mealType = LinkToAddCommand.MealType;
            productViewModel = new ProductViewModel();


            product = ProductViewModel.product;
            ProductSet.ID = Guid.NewGuid();
            ProductSet.IDProduct = product.ID;
            ProductSet.IDType = mealType;
            ProductSet.Date = base.Date;

            productSetRepository.Create(ProductSet);
             
            History.ID = Guid.NewGuid();
            History.IDProductSet = ProductSet.ID;
            History.IDUser = CurrentAccount.ID;

            historyRepository.Create(History);

            productViewModel.UpdateViewCommand.Execute("Filtering");
        }
    }
}
