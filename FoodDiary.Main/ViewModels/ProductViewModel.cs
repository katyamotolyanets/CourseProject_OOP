using FoodDiary.Core.Models;
using FoodDiary.Main.Commands;
using System.Windows.Input;

namespace FoodDiary.Main.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public static Product product { get; set; }
        public UpdateViewCommand UpdateViewCommand { get; set; }
        public ProductSet productSet { get; set; }
        public ICommand AddProductCommand { get; set; }
        public ProductViewModel()
        {
            product = new Product();
            product = MediatorCommand.product;
            productSet = new ProductSet();
            UpdateViewCommand = new UpdateViewCommand(MainWindow.MyMainView);
            AddProductCommand = new AddProductCommand(productSet);
        }
    }
}
