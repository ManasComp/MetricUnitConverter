using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MetricUnitConverter.Helpers;
using MetricUnitConverter.Models;
using MetricUnitConverter.Services;
using MetricUnitConverter.Views;
using Xamarin.Forms;

namespace MetricUnitConverter.ViewModels
{
    public class ConversionViewModel : BaseViewModel
    {
        public ICommand MainGroup => new Command(onUnitGroup);
        protected UnitGroup itemGroup;
        public UnitGroup ItemGroup
        {
            set => SetValue(ref itemGroup, value);
            get => itemGroup;
        }
        
        public ICommand FromUnit => new Command(onFromUnit);
        protected Unit fromItem;
        public Unit FromItem
        {
            set => SetValue(ref fromItem, value);
            get => fromItem;
        }
        
        public ICommand ToUnit => new Command(onToUnit);
        protected Unit toItem;
        public Unit ToItem
        {
            set => SetValue(ref toItem, value);
            get => toItem;
        }
        
        public ICommand Convert { get; set; }
        protected double from;
        public double From
        {
            set => SetValue(ref from, value);
            get => from;
        }
        
        protected double to;
        public double To
        {
            set => SetValue(ref to, value);
            get => to;
        }

        protected string fromText = "Tap to chose";//edit with lambda
        public string FromText
        {
            set => SetValue(ref fromText, value);
            get => fromText;
        }
        
        protected string toText = "Tap to chose";
        public string ToText
        {
            set => SetValue(ref toText, value);
            get => toText;
        }
        
        public ConversionViewModel()
        {
            _pageService = new PageService();
            Convert = new Command(async () => await ConvertTo());
            _data = new Data();
        }

        protected readonly PageService _pageService;
        private Data _data;
        
        private async Task ConvertTo()
        {
            if (From!=null && FromItem!=null && ToItem!=null)
                To = From * (FromItem.ConvertionToBasicUnit / ToItem.ConvertionToBasicUnit);
        }

        private async void onUnitGroup()
        {
            UnitGroupChoosingViewModel unitGroupChoosingViewModel = new UnitGroupChoosingViewModel(this);
            await _pageService.PushModalAsync(new UnitGroupChoosing(unitGroupChoosingViewModel));
        }
        
        private async void onFromUnit()
        {
            UnitChoosingViewModel unitChoosingViewModel = new UnitChoosingViewModel(ItemGroup, true, this);
            await _pageService.PushModalAsync(new UnitChoosing(unitChoosingViewModel));
        }
        
        private async void onToUnit()
        {
            UnitChoosingViewModel unitChoosingViewModel = new UnitChoosingViewModel(ItemGroup, false, this);
            await _pageService.PushModalAsync(new UnitChoosing(unitChoosingViewModel));
        }
    }
}