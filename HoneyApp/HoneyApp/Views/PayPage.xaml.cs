using HoneyApp.Models;
using HoneyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HoneyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PayPage : ContentPage
    {
        private Bill _bill; 
        public PayPage(Bill Bill)
        {
            InitializeComponent();
            _bill = Bill;
            BindingContext = new PayPageViewModel(Bill);
        }

        private  void Button_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                payRing.IsRunning = true;
                bRing.IsVisible = true;
            });
            Task.Run(() => StartPayment());
         
        }
        private async void StartPayment()
        {
            Thread.Sleep(3000);

            int id = await App.ServerService.NewOrder(_bill); ;

            Device.BeginInvokeOnMainThread(() =>
            {
                payRing.IsRunning = false;
                bRing.IsVisible = false;
            });
            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Оплата успішна", "Оплату проведено", "Ok");
                App.BasketService.ClearBasket();
                await Shell.Current.GoToAsync($"//{nameof(ProfilePage)}");

            });
        }

       

    
    
       
    }

    public class PayPageViewModel : BaseViewModel
    {
        public int Sum { get; set; }
        public PayPageViewModel( Bill bill)
        {
            foreach (var item in bill.Items)
            {
                Sum += item.Count * item.Prize;
            }
        }
    }
}