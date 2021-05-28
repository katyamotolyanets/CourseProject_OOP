using FoodDiary.Core.Exceptions;
using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.States.Accounts;
using FoodDiary.Main.ViewModels;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
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
            ProductViewModel.ErrorMessage = string.Empty;
            try
            {
                double weight = double.Parse(ProductViewModel.Weight.Replace(".", ","));
                if (!Regex.IsMatch(ProductViewModel.Weight, @"\d+(\.|\,){0,1}\d{1,2}") 
                    && weight == 0)
                {
                    throw new WrongValueException(ProductViewModel.productSetProducts.ProductWeight);
                }

                product = ProductViewModel.product;
                ProductSetProducts = new ProductSetProducts();
                ProductSetProducts.ID = Guid.NewGuid();
                ProductSetProducts.ProductID = product.ID;
                ProductSetProducts.ProductSetID = ProductSet.ID;
                ProductSetProducts.ProductWeight = weight;

                UnitOfWork unitOfWork = new UnitOfWork();
                unitOfWork.ProductSetProductsRepository.Create(ProductSetProducts);
                ProductViewModel.UpdateViewCommand.Execute("Diary");
            }
            catch (WrongValueException)
            {
                ProductViewModel.ErrorMessage = "Вес введён неверно";
            }
            catch (Exception)
            {
                ProductViewModel.ErrorMessage = "Неверные данные";
            }
        }
    }
}
