using HoneyApp.Models;
using HoneyApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HoneyApp.ViewModels
{
    public class BasketViewModel : BaseViewModel
    {
        public ObservableCollection<BasketProduct> Products { get; }
        public Command LoadItemsCommand { get; }
        public Command PayCommand { get; set; }
      

        private bool _isNoWares;
        public bool IsNoWares
        {
            get => _isNoWares;

            set
            {
                if (value != _isNoWares)
                {
                    _isNoWares = value;
                    OnPropertyChanged(nameof(IsNoWares));
                    if (IsNoWares)
                    {
                        ButtonLabel = "За покупками";
                    }
                    else
                        ButtonLabel = "Оплатити";
                }
            }
        }
        private string _buttonLabel;
        public string ButtonLabel
        {
            get => _buttonLabel;

            set
            {
                if (value != _buttonLabel)
                {
                    _buttonLabel = value;
                   
                    OnPropertyChanged(nameof(ButtonLabel));
                }
            }
        }

        public BasketViewModel()
        {
            Products = new ObservableCollection<BasketProduct>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            
            PayCommand = new Command(Pay);       
           
        }
        async void Pay()
        {
            if(IsNoWares)
            {
                await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");
            }
            else
            {
                var bill= new Bill()
                { 
                    Date = DateTime.Now,
                    Items = Products.Select(x => new BillItem() 
                    { 
                        Name = x.Name, 
                        Prize = x.Price, 
                        Count = x.Count
                    }).ToList()
                };

                await Shell.Current.Navigation.PushAsync(new PayPage(bill));
            }
        }
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Products.Clear();
                var items = await DataStore.GetBasketItemsAsync(App.BasketService.GetWares());
                foreach (var item in items)
                {
                    Products.Add(new BasketProduct() 
                    {
                        Name = item.Name,
                        Price = item.Price,
                        Icon = item.Icon,
                        Description = item.Description
                    });
                }
                IsNoWares = Products.Any() == false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }

        }

        public void OnAppearing()
        {
            IsBusy = true;            
        }

      

       

      
    }
}
