using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MetricUnitConverter
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            var page = new HelloWorld.ContactMethodsPage();
            page.ContactMethods.ItemSelected += (source, args)=>
            {
                contactMethod.Text = args.SelectedItem.ToString();
                Navigation.PopAsync();
            };


            Navigation.PushAsync(page);
        }
    }
}
