using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using System;
using System.Windows.Input;

namespace FoodDiary.Main.Commands
{
    public class EditCommand : ICommand
    { 
        public ProductSetProducts ProductSetProducts { get; set; }
        public EditCommand(ProductSetProducts ProductSetProducts)
        {
            this.ProductSetProducts = ProductSetProducts;
        }

        UnitOfWork UnitOfWork { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            UnitOfWork = new UnitOfWork();
            UnitOfWork.ProductSetProductsRepository.Edit(ProductSetProducts);
        }
    }
}
