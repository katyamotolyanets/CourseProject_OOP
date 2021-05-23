using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.Commands;
using System.Windows.Input;

namespace FoodDiary.Main.ViewModels
{
    public class EditProductSetViewModel : ProductViewModel
    {
        public ICommand EditCommand { get; set; }
        private ProductSetProducts _productSetProducts { get; set; }
        public UnitOfWork UnitOfWork { get; set; }

        public ProductSetProducts ProductSetProduct
        {
            get { return _productSetProducts; }
            set
            {
                _productSetProducts = value;
                OnPropertyChanged(nameof(ProductSetProduct));
            }
        }

        private Product _product { get; set; }

        public Product product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged(nameof(product));
            }
        }

        public EditProductSetViewModel()
        {
            UnitOfWork = new UnitOfWork();
            ProductSetProduct = new ProductSetProducts();
            product = new Product();
            
            ProductSetProduct = LinkToEditCommand.ProductSetProduct;
            product = UnitOfWork.ProductsRepository.Find(ProductSetProduct.ProductID);
            
            EditCommand = new EditCommand(ProductSetProduct);

        }
    }
}
