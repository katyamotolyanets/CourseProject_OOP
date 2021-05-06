using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using System;
using System.Windows.Input;

namespace FoodDiary.Main.Commands
{
    public class EditCommand : ICommand
    { 
        public ProductSet ProductSet { get; set; }
        public EditCommand(ProductSet productSet)
        {
            ProductSet = productSet;
        }

        ProductSetRepository ProductSetRepository = new ProductSetRepository();

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ProductSetRepository.Edit(ProductSet);
        }
    }
}
