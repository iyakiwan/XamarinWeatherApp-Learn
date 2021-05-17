using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WeatherApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage(WeatherData data)
        {
            InitializeComponent();
            BindingContext = data;
        }

        public DetailPage(EntitiyData data)
        {
            InitializeComponent();
            BindingContext = data;
        }

        public DetailPage(WaetherList data)
        {
            InitializeComponent();
            BindingContext = data;
        }
    }
}