using HoneyApp.ViewModels;
using HoneyApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace HoneyApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            SetTabBarIsVisible(this, false);
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(BasketPage), typeof(BasketPage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
            Routing.RegisterRoute(nameof(PayPage), typeof(PayPage));           

        }
        protected override bool OnBackButtonPressed( )
        {
            Current.GoToAsync("//LoginPage");
            return true;
        }
        

    }
}
