using ShopperApp.Models;
using ShopperApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopperApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {
        public ProductPage(ProductViewModel vm)
        {
            InitializeComponent();
        }

        private void SaveProduct(object sender, EventArgs e)
        {
            var product = (product)BindingContext;
            if (!String.IsNullOrEmpty(product.Name))
            {
                App.Database.SaveItem(product);
            }
            this.Navigation.PopAsync();
        }

        private void DeleteProduct(object sender, EventArgs e)
        {
            var product = (product)BindingContext;
            App.Database.DeleteItem(product.Id);
            this.Navigation.PopAsync();
        }
    }
}