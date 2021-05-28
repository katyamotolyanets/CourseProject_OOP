using FoodDiary.Core.Models;
using FoodDiary.Main.Commands;
using System.Windows.Input;

namespace FoodDiary.Main.ViewModels
{
    public class AddNewProductViewModel : BaseViewModel
    {
        //public string _calories { get; set; }
        public static string Calories { get; set; }
        //public string _energyV { get; set; }
        public static string EnergyV { get; set; }
        //public string _calo_proteins { get; set; }
        public static string Proteins { get; set; }
        public static string Fats { get; set; }
        public static string Carbohydrates { get; set; }
        public static Product product { get; set; }
        public ICommand NewProductCommand { get; set; }
        public MessageViewModel ErrorMessageViewModel { get; set; }
        public UpdateViewCommand UpdateViewCommand { get; set; }
        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }
        public AddNewProductViewModel()
        {
            ErrorMessageViewModel = new MessageViewModel();
            UpdateViewCommand = new UpdateViewCommand(MainWindow.MyMainView);
            product = new Product();
            NewProductCommand = new NewProductCommand(product, this);
        }
    }
}
