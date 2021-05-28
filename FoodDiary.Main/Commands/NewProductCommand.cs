using FoodDiary.Core.Exceptions;
using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.ViewModels;
using System;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace FoodDiary.Main.Commands
{
    public class NewProductCommand : ICommand
    {
        public Product product { get; set; }
        public ProductsRepository productsRepository { get; set; }
        AddNewProductViewModel addNewProductViewModel { get; set; }
        public NewProductCommand(Product product, AddNewProductViewModel addNewProductViewModel)
        {
            this.product = product;
            this.addNewProductViewModel = addNewProductViewModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                double calories = double.Parse(AddNewProductViewModel.Calories.Replace(".", ","));
                double energyV = double.Parse(AddNewProductViewModel.EnergyV.Replace(".", ","));
                double fats = double.Parse(AddNewProductViewModel.Fats.Replace(".", ","));
                double proteins = double.Parse(AddNewProductViewModel.Proteins.Replace(".", ","));
                double carbohydrates = double.Parse(AddNewProductViewModel.Carbohydrates.Replace(".", ","));
                if (!Regex.IsMatch(AddNewProductViewModel.Calories, @"^\d{3,4}((\.|\,){0,1}\d{0,2}){0,1}$"))
                {
                    throw new WrongValueException(product.Calories);
                }
                if (!Regex.IsMatch(AddNewProductViewModel.Fats, @"^\d{2,3}((\.|\,){0,1}\d{0,2}){0,1}$"))
                {
                    throw new WrongValueException(product.Fats);
                }
                if (!Regex.IsMatch(AddNewProductViewModel.Proteins, @"^\d{2,3}((\.|\,){0,1}\d{0,2}){0,1}$"))
                {
                    throw new WrongValueException(product.Proteins);
                }
                if (!Regex.IsMatch(AddNewProductViewModel.Carbohydrates, @"^\d{2,3}((\.|\,){0,1}\d{0,2}){0,1}$"))
                {
                    throw new WrongValueException(product.Carbohydrates);
                }
                if (!Regex.IsMatch(AddNewProductViewModel.EnergyV, @"^\d{3,4}((\.|\,){0,1}\d{0,2}){0,1}$"))
                {
                    throw new WrongValueException(product.EnergyValue);
                }
                if (!Regex.IsMatch(AddNewProductViewModel.product.NameProduct, @"[А-Яа-я]+\s{0,1}"))
                {
                    throw new WrongNameException(product.NameProduct);
                }
                productsRepository = new ProductsRepository();
                product = AddNewProductViewModel.product;
                product.ID = Guid.NewGuid();
                product.Calories = calories;
                product.EnergyValue = energyV;
                product.Fats = fats;
                product.Proteins = proteins;
                product.Carbohydrates = carbohydrates;
                product.IconSource = @"..\Assets\Products\product.png";
                addNewProductViewModel.UpdateViewCommand.Execute("Diary");

                productsRepository.Create(product);
            }
            catch(WrongValueException)
            {
                addNewProductViewModel.ErrorMessage = "Числовые значения введены неверно";
            }
            catch (WrongNameException)
            {
                addNewProductViewModel.ErrorMessage = "Некорректное название";
            }
            catch (Exception)
            {
                addNewProductViewModel.ErrorMessage = "Данные введены неверно";
            }
        }
    }
}
