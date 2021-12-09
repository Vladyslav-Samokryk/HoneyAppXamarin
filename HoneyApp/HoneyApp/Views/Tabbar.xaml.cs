using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HoneyApp.Views;

namespace HoneyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tabbar : ContentView
    {
        public int CorrectIndex
        {
            get => CorrectIndex;
            set
            {
                FontImage correctTab = tabs.Children[value] as FontImage;
                correctTab.Color = Color.Orange;
                correctTab.IsEnabled = false;
            }
        }
        public string[] Pages = new string[]
        {
            nameof(AboutPage), nameof(ItemsPage), nameof(BasketPage), nameof(ProfilePage)
        };
        public Tabbar()
        {
            InitializeComponent();
            for (int i = 0; i < Pages.Length; i++)
            {
                FontImage correctTab = tabs.Children[i] as FontImage;
                correctTab.NavigationPage = Pages[i];
            }
        }
    }
}