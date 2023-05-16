using ShopperApp.Models;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopperApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {
        public CartPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            productsList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            product SelectedProduct = (product)e.SelectedItem;
            CartPage productPage = new CartPage();
            productPage.BindingContext = SelectedProduct;
            await Navigation.PushAsync(productPage);
        }

        private async void CreateProduct(object sender, EventArgs e)
        {
            product product = new product();
            CartPage productPage = new CartPage();
            productPage.BindingContext = product;
            await Navigation.PushAsync(productPage);
        }

    }
}