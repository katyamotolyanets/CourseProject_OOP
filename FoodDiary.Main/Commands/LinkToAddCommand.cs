using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Data;
using System.Windows.Input;

namespace FoodDiary.Main.Commands
{
    public class LinkToAddCommand : ICommand
    {
        DiaryViewModel diaryViewModel { get; set; }
        public static Guid MealType { get; set; }
        public static ProductSet ProductSet { get; set; }
        public List<ProductSet> productSets { get; set; }
        public LinkToAddCommand(DiaryViewModel diaryViewModel)
        {
            this.diaryViewModel = diaryViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MealType mealType = (MealType)parameter;
            //MealType = Guid.Parse((string)parameter);
            ProductSet = new ProductSet();
            //foreach(var item in mealType.ProductSets)
            //{
            //    ProductSet.ID = item.ID;
            //}
            ProductSet.IDType = mealType.ID;
            diaryViewModel.BindProductSets();
            productSets = new List<ProductSet>();
            productSets = diaryViewModel.ProductSets;

            foreach (ProductSet productSet in productSets)
            {
                if (productSet.IDType == ProductSet.IDType)
                {
                    ProductSet.ID = productSet.ID;
                }
            }

            ProductSet = new UnitOfWork().ProductSetRepository.Find(ProductSet.ID);
            diaryViewModel.UpdateViewCommand.Execute("Filtering");

        }
    }
}
