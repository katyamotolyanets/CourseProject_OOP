using FoodDiary.Core.Models;
using FoodDiary.Infrastructure.Repositories;
using FoodDiary.Main.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace FoodDiary.Main.ViewModels
{
    public class FilteringViewModel : BaseViewModel
    {
        public List<Product> Products { get; set; }
        public ICommand MediatorCommand { get; set; }
        public ProductsRepository productsRepository { get; set; }
        public UpdateViewCommand UpdateViewCommand { get; set; }
        public ICollectionView ProductsCollectionView { get; set; }
        private string _productsFilter = string.Empty;
        public string ProductsFilter
        {
            get
            {
                return _productsFilter;
            }
            set
            {
                _productsFilter = value;
                OnPropertyChanged(nameof(ProductsFilter));
                ProductsCollectionView.Refresh();
            }
        }
        public FilteringViewModel()
        {
            Products = new List<Product>();
            productsRepository = new ProductsRepository();
            UpdateViewCommand = new UpdateViewCommand(MainWindow.MyMainView);
            GetProducts();
            MediatorCommand = new MediatorCommand(this);
            ProductsCollectionView = CollectionViewSource.GetDefaultView(Products);
            ProductsCollectionView.Refresh();
            ProductsCollectionView.Filter = FilterProducts;
        }

        private bool FilterProducts(object obj)
        {
            if (obj is Product product)
            {
                return product.NameProduct.ToUpper().Contains(ProductsFilter.ToUpper());
            }

            return false;
        }

        public void GetProducts()
        {
            Products = (List<Product>)productsRepository.List();
        }
    }
}
