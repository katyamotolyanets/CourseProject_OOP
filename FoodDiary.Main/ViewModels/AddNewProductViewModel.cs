using FoodDiary.Core.Models;
using FoodDiary.Main.Commands;
using System.Windows.Input;

namespace FoodDiary.Main.ViewModels
{
    public class AddNewProductViewModel : BaseViewModel
    {
        public static Product product { get; set; }
        public ICommand NewProductCommand { get; set; }

        public AddNewProductViewModel()
        {
            product = new Product();
            NewProductCommand = new NewProductCommand(product);
        }
    }
}
