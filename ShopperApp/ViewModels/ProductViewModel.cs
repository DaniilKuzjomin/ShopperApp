using ShopperApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using static Xamarin.Essentials.Permissions;
using Xamarin.Essentials;

namespace ShopperApp.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ProductListViewModel lvm;
        internal ProductListViewModel ProductListViewModel;

        public product product { get; private set; }

        public ProductViewModel()
        {
            product= new product();
        }

        public ProductListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }
        public string Name
        {
            get { return product.Name; }
            set
            {
                if (product.Name != value)
                {
                    product.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Quantity
        {
            get { return product.Quantity; }
            set
            {
                if (product.Quantity != value)
                {
                    product.Quantity = value;
                    OnPropertyChanged("Quantity");
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return !string.IsNullOrEmpty(Name.Trim()) ||
                    !string.IsNullOrEmpty(Quantity.Trim());

            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

    }
}
