using HoneyApp.Services;
using HoneyApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HoneyApp
{
    public partial class App : Application
    {
        public static IServerService ServerService { get; set; } = new ServerService();
        public static IBasketService BasketService { get; set; } = new BasketWareService();
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
