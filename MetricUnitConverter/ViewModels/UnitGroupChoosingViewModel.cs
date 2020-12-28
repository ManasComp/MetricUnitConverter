using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MetricUnitConverter.Models;
using MetricUnitConverter.Services;
using MetricUnitConverter.Views;
using Xamarin.Forms;
using Color = System.Drawing.Color;

namespace MetricUnitConverter.ViewModels
{
    public class UnitGroupChoosingViewModel : ChoosingBaseViewModel
    {
        public ObservableCollection<UnitGroup> Collection { get; private set; }
        
        public UnitGroupChoosingViewModel(ConversionViewModel conversionViewModel)
        {
            zdroje = new Data();
            Collection = new ObservableCollection<UnitGroup>(zdroje.Group);
            Clicked = new Command(async () => await onSelected());
            _pageService = new PageService();
            _conversionViewModel = conversionViewModel;
        }

        public UnitGroupChoosingViewModel()
        {
            
        }
        public ICommand Clicked { get; set; }
        protected UnitGroup _selectedItem;
        public UnitGroup SelectedItem
        {
            set => SetValue(ref _selectedItem, value);
            get => _selectedItem;
        } 
        private async Task onSelected()
        {
            _conversionViewModel.ItemGroup = SelectedItem;
            _conversionViewModel.FromItem = null;
            _conversionViewModel.ToItem = null;
            await _pageService.PushModalAsync(new Conversion(_conversionViewModel));
        }
    }
}