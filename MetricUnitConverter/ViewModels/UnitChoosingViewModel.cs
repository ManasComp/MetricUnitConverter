using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MetricUnitConverter.Models;
using MetricUnitConverter.Services;
using MetricUnitConverter.Views;
using Xamarin.Forms;

namespace MetricUnitConverter.ViewModels
{
    public class UnitChoosingViewModel: ChoosingBaseViewModel
    {
        public ObservableCollection<Unit> Collection { get; private set; }

        public UnitChoosingViewModel()
        {
            
        }
        public UnitChoosingViewModel(UnitGroup group, bool side, ConversionViewModel conversionViewModel)
        {
            Collection = new ObservableCollection<Unit>(group);
            Clicked = new Command(async () => await onSelected());
            _pageService = new PageService();
            _side = side;
            _conversionViewModel = conversionViewModel;
        }
        private bool _side = false;
        public ICommand Clicked { get; set; }
        
        protected Unit _selectedItem;
        public Unit SelectedItem
        {
            set => SetValue(ref _selectedItem, value);
            get => _selectedItem;
        }

        private async Task onSelected()
        {
            ConversionViewModel conversionViewModel;
            if (_side)
            {
                _conversionViewModel.FromItem = SelectedItem;
                _conversionViewModel.FromText = SelectedItem.ShortName;
            }
            else
            {
                _conversionViewModel.ToItem = SelectedItem;
                _conversionViewModel.ToText = SelectedItem.ShortName;
            }
                
            await _pageService.PushModalAsync(new Conversion(_conversionViewModel));
        }
    }
}