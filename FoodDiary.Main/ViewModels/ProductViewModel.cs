using FoodDiary.Core.Models;
using FoodDiary.Main.Commands;
using System;
using System.Windows.Input;

namespace FoodDiary.Main.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public static Product product { get; set; }
        public ProductSet ProductSet { get; set; }
        public UpdateViewCommand UpdateViewCommand { get; set; }
        public ProductSetProducts productSetProducts { get; set; }
        public UserHistory history { get; set; }
        public ICommand AddProductCommand { get; set; }
        
        public ProductViewModel()
        {
            product = new Product();
            product = MediatorCommand.product;
            productSetProducts = new ProductSetProducts();
            ProductSet = new ProductSet();
            ProductSet = LinkToAddCommand.ProductSet;
            UpdateViewCommand = new UpdateViewCommand(MainWindow.MyMainView);
            AddProductCommand = new AddProductCommand(ProductSet, this);
        }
    }
}
