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
        public ProductSet ProductSet { get; set; }
        public LinkToAddCommand LinkToAddCommand { get; set; }
        public ProductViewModel ProductViewModel { get; set; }

        public AddProductCommand(ProductSet productSet, ProductViewModel productViewModel)
        {
            ProductSet = productSet;
            ProductViewModel = productViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            product = ProductViewModel.product;
            ProductSetProducts = new ProductSetProducts();
            ProductSetProducts.ID = Guid.NewGuid();
            ProductSetProducts.ProductID = product.ID;
            ProductSetProducts.ProductSetID = ProductSet.ID;
            ProductSetProducts.ProductWeight = ProductViewModel.productSetProducts.ProductWeight;

            UnitOfWork unitOfWork = new UnitOfWork();
            unitOfWork.ProductSetProductsRepository.Create(ProductSetProducts);
            ProductViewModel.UpdateViewCommand.Execute("Diary");
        }
    }
}
