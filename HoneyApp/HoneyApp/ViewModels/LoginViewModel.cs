using HoneyApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HoneyApp.ViewModels
{
    public static class Data
    {
        public static string Login => "Biber";

        public static string Password => "01234567";
    }
    public class LoginViewModel : BaseViewModel
    {
        public string Login { get; set; }

        private string _message = "";

        public string Meassage 
        { get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Meassage));
            }
        }

        public string  Password { get; set; }

        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            if(Login != Data.Login)
            {
                Meassage = "Перевірте логін";
            }
            else if(Password != Data.Password)
            {
                Meassage = "Невірний пароль";
            }
            else
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
