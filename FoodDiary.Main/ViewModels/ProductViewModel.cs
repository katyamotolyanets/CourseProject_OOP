using FoodDiary.Core.Models;
using FoodDiary.Main.Commands;
using System;
using System.Windows.Input;

namespace FoodDiary.Main.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public static Product product { get; set; }
        
        public new UpdateViewCommand UpdateViewCommand { get; set; }
        public ProductSet productSet { get; set; }
        public UserHistory history { get; set; }
        public ICommand AddProductCommand { get; set; }
        public ProductViewModel()
        {
            product = new Product();
            product = MediatorCommand.product;
            productSet = new ProductSet();
            history = new UserHistory();
            UpdateViewCommand = new UpdateViewCommand(MainWindow.MyMainView);
            AddProductCommand = new AddProductCommand(productSet, history);
        }
    }
}
