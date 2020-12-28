using MetricUnitConverter.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MetricUnitConverter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Conversion : ContentPage
    {
        public Conversion(ConversionViewModel conversionViewModel=null)
        {
            InitializeComponent();
            if (conversionViewModel!=null)
                this.BindingContext = conversionViewModel;
            else
                this.BindingContext = new ConversionViewModel();
        }
    }
}