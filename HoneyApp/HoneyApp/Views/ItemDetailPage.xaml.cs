using HoneyApp.Models;
using HoneyApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace HoneyApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage(Product product )
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel(product);
           
        }
    }
}