using HoneyApp.Models;
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
    public class ProfileViewModel : BaseViewModel
    {
        public event Action DataLoaded;
        public Command LoadItemsCommand { get; }
        public ObservableCollection<BillModel> Bills { get; set; }
        public ProfileViewModel()
        {
            Bills = new ObservableCollection<BillModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Bills.Clear();
                var items = (await App.ServerService.GetBills())
                    .Select(x => new BillModel()
                    {
                        Id = x.Key,
                        Date = x.Value.Date,
                        BillItems = x.Value.Items
                     });

                foreach (var item in items)
                {
                    Bills.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
                DataLoaded?.Invoke();
            }
        }
        public void OnAppearing()
        {
            IsBusy = true;
           
        }
    }
}
