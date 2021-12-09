using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace HoneyApp.Models
{
    public class BasketProduct :Product, INotifyPropertyChanged
    {
        public Command AddCommand { get;}
        public Command RemoveCommand { get;}
        private int _count = 1;
        public int Count 
        { 
            get => _count;
            set
            { 
                if(value >= 1 && _count != value)
                {
                    _count = value;
                    OnPropertyChanged(nameof(Count));
                }
            } 
        }
        public BasketProduct()
        {
            AddCommand = new Command(() => ++Count);
            RemoveCommand = new Command(() => --Count);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;
            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
