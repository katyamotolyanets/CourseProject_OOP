using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.ViewModels;
using System;
using System.Windows.Input;

namespace FoodDiary.Main.Commands
{
    public class AddProductCommand : ICommand
    {
        public ProductSet ProductSet { get; set; }
        public ProductSetRepository productSetRepository = new ProductSetRepository();
        public Product product { get; set; }
        public Guid mealType { get; set; }
        public ProductViewModel productViewModel { get; set; }
        public AddProductCommand(ProductSet productSet)
        {
            ProductSet = productSet;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mealType = LinkToAddCommand.MealType;
            productViewModel = new ProductViewModel();

            product = ProductViewModel.product;
            ProductSet.ID = Guid.NewGuid();
            ProductSet.IDProduct = product.ID;
            ProductSet.IDType = mealType;
            ProductSet.Date = DateTime.Now;

            productSetRepository.Create(ProductSet);

            productViewModel.UpdateViewCommand.Execute("Filtering");
        }
    }
}
