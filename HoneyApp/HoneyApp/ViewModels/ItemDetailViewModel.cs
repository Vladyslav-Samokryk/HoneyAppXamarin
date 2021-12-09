using HoneyApp.Models;
using HoneyApp.Views;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HoneyApp.ViewModels
{
    [QueryProperty(nameof(Product), nameof(Product))]
    public class ItemDetailViewModel : INotifyPropertyChanged
    {
        public Command<int> AddToBasket { get; }
        public int Id  => _product.Id;
        public ItemDetailViewModel(Product product)
        {
            Product = product;
            AddToBasket = new Command<int>(AddToBasketMethod);
        }
        private async void AddToBasketMethod(int id)
        {
            App.BasketService.AddWare(id);
            await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");
        }
        private  Product _product;
        byte[] _image;
        public string Title 
        { 
            get => _product.Name;
            set => OnPropertyChanged(nameof(Title)); 
        }
        public int Price 
        { 
            get=> _product.Price; 
            set
            {
                _product.Price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public byte[] ProductImage
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged(nameof(ProductImage));
            }
        }
        public string Name
        {
            get => _product.Name;
            set 
            {
                _product.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get => _product.Description;
            set
            {
                _product.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public Product Product
        {
            get
            {
                return _product;
            }
            set
            {
                
                LoadProduct(value);
            }
        }

        private async void LoadProduct(Product value)
        {
            _product = new Product()
            {
                Name = value.Name,
                Description = value.Description,
                Id = value.Id,
                Price = value.Price
            };
             ProductImage = await App.ServerService.GetPhoto(_product.Id);


        }

       
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
   

}
