using StoreManager.Entities;
using StoreManager.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Products
{
    public class ProductListViewModel
    {
        private IProductsRepository _repository = new ProductsRepository();

        public ProductListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;

            Products = new ObservableCollection<Product>(_repository.GetProductsAsync().Result);
        }

        public ObservableCollection<Product> Products { get; set; }
    }
}
