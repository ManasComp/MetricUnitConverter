using System.Collections.ObjectModel;
using System.Windows.Input;
using MetricUnitConverter.Models;
using MetricUnitConverter.Services;

namespace MetricUnitConverter.ViewModels
{
    public class ChoosingBaseViewModel:BaseViewModel
    {
        protected PageService _pageService;
        protected Data zdroje;
        protected ConversionViewModel _conversionViewModel;
    }
}