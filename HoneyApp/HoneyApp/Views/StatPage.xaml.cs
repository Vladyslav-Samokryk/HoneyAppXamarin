using Microcharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HoneyApp.Models;

namespace HoneyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatPage : ContentPage
    {
        private static SKColor[] _colors = new string[6] {"#6a2202", "#9a5702", "#bc7201", "#e5ab09",
                "#ecb943", "#22180d"}.Select(x => SKColor.Parse(x)).ToArray();
        //private static SKColor[] _colors = new SKColor [6] {SKColors.Red, SKColors.Green, SKColors.Orange, 
        //    SKColors.Yellow, SKColors.LightYellow, SKColors.Beige};
        public StatPage( BillModel [] bills)
        {
            InitializeComponent();
            Dictionary<string, int> vall = new Dictionary<string, int>();
            foreach (var bill in bills)
            {
                foreach (var item in bill.BillItems)
                {
                    if (vall.ContainsKey(item.Name))
                    {
                        vall[item.Name] += item.Count;
                    }
                    else
                        vall.Add(item.Name, item.Count);

                }
            }
            
            var entries = vall.Select(x => new ChartEntry(x.Value)
            {
                Label = x.Key,
                ValueLabel = x.Value.ToString(),
                TextColor = SKColors.Black,
                ValueLabelColor = SKColors.Black

            }).ToArray();
            for (int i = 0; i < entries.Length; i++)
            {
                entries[i].Color = _colors[i%6];
            }
            
              
            var chart = new BarChart() 
            { 
                
                Entries = entries,
                LabelTextSize = 45,
              
                ValueLabelOrientation = Orientation.Horizontal,
                LabelOrientation = Orientation.Vertical,
                
               
            };
            chartView.Chart = chart;
            
        }
    }
}