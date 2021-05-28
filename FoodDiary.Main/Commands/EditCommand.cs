using FoodDiary.Core.Exceptions;
using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.ViewModels;
using System;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace FoodDiary.Main.Commands
{
    public class EditCommand : ICommand
    { 
        public EditProductSetViewModel editProductSetViewModel { get; set; }
        public ProductSetProducts ProductSetProducts { get; set; }
        public EditCommand(ProductSetProducts ProductSetProducts, EditProductSetViewModel editProductSetViewModel)
        {
            this.ProductSetProducts = ProductSetProducts;
            this.editProductSetViewModel = editProductSetViewModel;
        }

        UnitOfWork UnitOfWork { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                if (!Regex.IsMatch(editProductSetViewModel.ProductSetProduct.ProductWeight.ToString(), @"\d+(\.|\,){0,1}\d{1,2}") && editProductSetViewModel.ProductSetProduct.ProductWeight == 0)
                {
                    throw new WrongValueException(editProductSetViewModel.ProductSetProduct.ProductWeight);
                }
                UnitOfWork = new UnitOfWork();
                UnitOfWork.ProductSetProductsRepository.Edit(ProductSetProducts);
                editProductSetViewModel.UpdateViewCommand.Execute("Diary");
            }
            catch(WrongValueException)
            {
                editProductSetViewModel.ErrorMessage = "Вес введён неверно";
            }
            catch(Exception)
            {
                editProductSetViewModel.ErrorMessage = "Неверные данные";

            }
        }
    }
}
