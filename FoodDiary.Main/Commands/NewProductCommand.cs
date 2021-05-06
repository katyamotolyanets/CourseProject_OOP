using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.ViewModels;
using System;
using System.Windows.Input;

namespace FoodDiary.Main.Commands
{
    public class NewProductCommand : ICommand
    {
        public Product product { get; set; }
        public ProductsRepository productsRepository { get; set; }
        public NewProductCommand(Product product)
        {
            this.product = product;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            productsRepository = new ProductsRepository();
            product = AddNewProductViewModel.product;
            product.ID = Guid.NewGuid();

            productsRepository.Create(product);
        }
    }
}
