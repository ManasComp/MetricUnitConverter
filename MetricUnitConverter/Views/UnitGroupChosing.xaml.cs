using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetricUnitConverter.Models;
using MetricUnitConverter.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MetricUnitConverter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UnitGroupChoosing : ContentPage
    {
        public UnitGroupChoosing( UnitGroupChoosingViewModel unitGroupChoosingViewModel = null) 
        {
            InitializeComponent();
            if (unitGroupChoosingViewModel != null)
                this.BindingContext = unitGroupChoosingViewModel;
            else
                this.BindingContext = new UnitGroupChoosingViewModel(null);
        }
        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (BindingContext as UnitGroupChoosingViewModel).Clicked.Execute(null);
        }
    }
}