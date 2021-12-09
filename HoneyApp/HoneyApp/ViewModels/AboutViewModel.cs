using HoneyApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HoneyApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private static List<ImageSource> _images = new List<ImageSource>()
        {
            ImageSource.FromResource("HoneyApp.Images." + "honey1.jpg"),
            ImageSource.FromResource("HoneyApp.Images." + "honey2.jpg"),
            ImageSource.FromResource("HoneyApp.Images." + "honey3.jpg"),
        };
        private Product _product;
        public Product Product
        { 
            get => _product;
            set
            {
                _product = value;
                OnPropertyChanged(nameof(Product));
            } 
        }
        public List<ImageSource> Images { get => _images; }
        public AboutViewModel()
        {
            _ = GetProduct();
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }

        private async Task GetProduct()
        {
            Product = await App.ServerService.GetProduct();
        }
    }
}