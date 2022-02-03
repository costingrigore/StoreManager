using StoreManager.Entities;
using StoreManager.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace StoreManager.Products
{
    public class ProductListViewModel : INotifyPropertyChanged
    {
        private IProductsRepository _repository = new ProductsRepository();

        private ObservableCollection<Product> _products;

        public ProductListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;

           
        }

        public ObservableCollection<Product> Products
        {
            get
            {
                return _products;
            }
            private set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task LoadProducts()
        {
            var products = await _repository.GetProductsAsync();
            Products = new ObservableCollection<Product>(products);
        }
    }
}
