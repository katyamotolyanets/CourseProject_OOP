using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.States.Accounts;
using FoodDiary.Main.ViewModels;
using System;
using System.Windows.Input;

namespace FoodDiary.Main.Commands
{
    public class AddProductCommand : ICommand
    {
        public ProductSetProducts ProductSetProducts { get; set; }
        public ProductSetProductsRepository productSetProductsRepository = new ProductSetProductsRepository();
        public Product product { get; set; }
        public Guid mealType { get; set; }
        public ProductViewModel productViewModel { get; set; }
        public DiaryViewModel diaryViewModel { get; set; }
        public User CurrentAccount { get; set; }

        
        public AddProductCommand(ProductSetProducts productSetProducts)
        {
            ProductSetProducts = productSetProducts;
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

            ProductSetProducts.ID = Guid.NewGuid();
            ProductSetProducts.Product = product;
            //ProductSetProducts.ProductSet = 
            //ProductSet.IDProduct = product.ID;
            //ProductSet.IDType = mealType;
             

            productViewModel.UpdateViewCommand.Execute("Filtering");
        }
    }
}
