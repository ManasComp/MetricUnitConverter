using MetricUnitConverter.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MetricUnitConverter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UnitChoosing : ContentPage
    {
        public UnitChoosing(UnitChoosingViewModel unitChoosingViewModel = null)
        {
            InitializeComponent();
            if (unitChoosingViewModel != null)
                this.BindingContext = unitChoosingViewModel;
            else
                this.BindingContext = new UnitChoosingViewModel(null, false, null);
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (BindingContext as UnitChoosingViewModel).Clicked.Execute(null);
        }
    }
}