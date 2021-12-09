using HoneyApp.Presentation;
using HoneyApp.ViewModels;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HoneyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        private readonly ProfileViewModel _viewModel;
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = _viewModel =  new ProfileViewModel();
            _viewModel.DataLoaded += _viewModel_DataLoaded;
          
        }

        private void _viewModel_DataLoaded()
        {
            bills.ScrollTo(_viewModel.Bills.Last(), ScrollToPosition.End);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new TestPage());
            Navigation.PushPopupAsync(new PageOne());
        }
        protected override void OnAppearing()
        {
            _viewModel.OnAppearing();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StatPage(_viewModel.Bills.ToArray()));
        }
    }
}