using ShopperApp.Views;
using ShopperApp.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System;
using System.Text;
using Xamarin.Forms;

namespace ShopperApp.ViewModels
{
    public class ProductListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ProductViewModel> Products { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CreateProductCommand {  protected get; set; }
        public ICommand DeleteProductCommand { protected get; set; }
        public ICommand SaveProductCommand { protected get; set; }
        public ICommand BackCommand { protected get; set; }
        ProductViewModel selectedProduct;
        public INavigation Navigation { get; set; }



        public ProductListViewModel() 
        {
            Products = new ObservableCollection<ProductViewModel>();
            CreateProductCommand = new Command(Create);
            DeleteProductCommand = new Command(Delete);
            BackCommand = new Command(Back);
        }
        
        public ProductViewModel SelectedProduct
        {
            get { return selectedProduct; } set
            {
                if (selectedProduct != value)
                {
                    ProductViewModel tempProduct = value;
                    selectedProduct = null;
                    OnPropertyChanged("SelectedProduct");
                    Navigation.PushAsync(new ProductPage(tempProduct));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void Create()
        {
            Navigation.PushAsync(new ProductPage(new ProductViewModel() { ListViewModel = this }));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }
        private void SaveFriend(object friendObject)
        {
            ProductViewModel friend = friendObject as ProductViewModel;
            if (friend != null && friend.IsValid && !Products.Contains(friend))
            {
                Products.Add(friend);
            }
            Back();
        }
        private void Delete(object friendObject)
        {
            ProductViewModel friend = friendObject as ProductViewModel;
            if (friend != null)
            {
                Products.Remove(friend);
            }
            Back();
        }

    }
}
