using FoodDiary.Core.Models;
using FoodDiary.Main.Commands;
using System.Windows.Input;

namespace FoodDiary.Main.ViewModels
{
    public class EditProductSetViewModel : ProductViewModel
    {
        public ICommand EditCommand { get; set; }
        private ProductSet _productSet { get; set; }

        public ProductSet ProductSet
        {
            get { return _productSet; }
            set
            {
                _productSet = value;
                OnPropertyChanged(nameof(_productSet));
            }
        }

        private Product _product { get; set; }

        public Product product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged(nameof(_product));
            }
        }

        public EditProductSetViewModel()
        {
            ProductSet = new ProductSet();
            product = new Product();

            ProductSet = LinkToEditCommand.ProductSet;
            //product = ProductSet.Product;
            EditCommand = new EditCommand(ProductSet);

        }
    }
}
